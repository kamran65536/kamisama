param([parameter(Position=0)][string]$ProjectName, [parameter(Position=1)][string]$Database = "all")


Class MigrationContext{
	[string]$StartupProject
	[string]$ProjectName
	[string]$Environment
	[string]$DbContextName
	[string]$ExpectedMigration
	[string]$OldMigration
	[Boolean]$needSolutionBuild

	MigrationContext($StartupProject, $ProjectName, $Environment, $DbContextName, $OldMigration, $ExpectedMigration)
	{
		$this.StartupProject = $StartupProject
		$this.ProjectName = $ProjectName
		$this.Environment = $Environment
		$this.ExpectedMigration = $ExpectedMigration
		$this.DbContextName = $DbContextName
		$this.needSolutionBuild = $true
		$this.OldMigration = $OldMigration
	}
	[void]BuildStartupProjectIfNeeded()
	{
		if (!$this.needSolutionBuild)
		{
			return;
		}

		Write-Host "	- Building solution..."
		dotnet build $this.StartupProject
		Write-Host "	- done."
		$this.needSolutionBuild = $false
	}
	[Object[]]ListMigrations()
	{
		return dotnet ef migrations list --json --prefix-output -p $this.ProjectName -s $this.StartupProject -c $this.DbContextName -- --environment $this.Environment |
			where { $_.StartsWith('data:') } |
			foreach { $_.Substring(5) } |
			ConvertFrom-Json
	}
	[Object] GetLastMigration()
	{
		$arr = $this.ListMigrations()

		if ($arr.Length -eq 0)
		{
			return $null
		}
		else
		{
			return $arr[$arr.Length-1]
		}
	}
	[Boolean] HasAnyChanges()
	{
		$has_pending_changes=dotnet ef migrations has-pending-model-changes --prefix-output  -p $this.ProjectName -s $this.StartupProject -c $this.DbContextName -- --environment $this.Environment |
			where { $_.StartsWith('error:') }
		
		return $has_pending_changes.Count -ne 0
	}
	RebuildMigrations()
	{
		Write-Host "*********** Rebuilding Migrations ***************"
		Write-Host "Migration Project name: $($this.ProjectName)"
		Write-Host "Startup Project name  : $($this.StartupProject)"
		Write-Host "Environment           : $($this.Environment)"
		Write-Host "OldMigration          : $($this.OldMigration)"
		Write-Host "ExpectedMigration     : $($this.ExpectedMigration)"
		
		$this.BuildStartupProjectIfNeeded()

		$lastMigration=$this.GetLastMigration()

		if (!$this.HasAnyChanges() -and ($lastMigration -ne $null) -and ($lastMigration.name -eq $this.ExpectedMigration))
		{
			Write-Host "	- Model is up to date. no change is needed."
			return;
		}

		Write-Host "	- Migration changes is needed."

		if ($lastMigration -ne $null)
		{
			$this.BuildStartupProjectIfNeeded()
			
			if (($this.OldMigration -ne $null) -and ($lastMigration.name -eq $this.OldMigration))
			{
				Write-Host "	- Migration changes is completely new."
			}
			else
			{
				Write-Host "	- Removing migration $($lastMigration.name) ..."
				$removeResult = dotnet ef migrations remove -f --no-build -p $this.ProjectName -s $this.StartupProject -c $this.DbContextName  -- --environment $this.Environment 
				
				Write-Host "	- Remove result is $removeResult"
				$this.needSolutionBuild = $true
			}
		}

		$this.BuildStartupProjectIfNeeded()
		Write-Host "	- Adding new migration named $($this.ExpectedMigration)"
		$isRunningWindows = $env:OS -eq "Windows_NT"

		# Assign the appropriate command based on the operating system
		if ($isRunningWindows) {
			Write-Host " running on windows"
			$command = "dotnet ef migrations add $($this.ExpectedMigration) -p $($this.ProjectName) -s $($this.StartupProject) -c $($this.DbContextName) -o Repositories\Database\$($this.Environment)\Migrations -- --environment $($this.Environment)"
			Write-Host "running : {$command}"
			$Output = Invoke-Expression $command
			Write-Host $Output
		} else {
			Write-Host " running on unix"
			$command = "dotnet ef migrations add $($this.ExpectedMigration) -p $($this.ProjectName) -s $($this.StartupProject) -c $($this.DbContextName) -o Repositories/Database/$($this.Environment)/Migrations -- --environment $($this.Environment)"
			Write-Host "running : {$command}"
			$Output = Invoke-Expression $command
			Write-Host $Output
		}
	}
}

$currentVersion = $null;
$nextVersion = "V1_0_0";

$all=@{
	identity = @{ 
		Sqlite = [MigrationContext]::New("TestApiServer", "KamiSama.Modules.Identity.Sqlite", "sqlite", "SqlitePolareumIdentityDbContext", $currentVersion, $nextVersion);
		Postgresql = [MigrationContext]::New("TestApiServer", "KamiSama.Modules.Identity.Posgtgresql", "postgresql", "PostgresqlPolareumIdentityDbContext", $currentVersion, $nextVersion);
	};
	locations = @{
		Sqlite = [MigrationContext]::New("TestApiServer", "KamiSama.Modules.Locations.Sqlite", "sqlite", "SqliteLocationsDbContext", $currentVersion, $nextVersion);
		Postgresql = [MigrationContext]::New("TestApiServer", "KamiSama.Modules.Locations.Posgtgresql", "postgresql", "PostgresqlLocationsDbContext", $currentVersion, $nextVersion);
	};
	otp = @{
		Sqlite = [MigrationContext]::New("TestApiServer", "KamiSama.Modules.Otp.Sqlite", "sqlite", "SqliteOtpDbContext", $currentVersion, $nextVersion);
		Postgresql = [MigrationContext]::New("TestApiServer", "KamiSama.Modules.Otp.Postgresql", "postgresql", "PostgresqlOtpDbContext", $currentVersion, $nextVersion);
	};
	policyengine = @{
		Sqlite = [MigrationContext]::New("TestApiServer", "KamiSama.Modules.PolicyEngine.Sqlite", "sqlite", "SqlitePolicyEngineDbContext", $currentVersion, $nextVersion);
		Postgresql = [MigrationContext]::New("TestApiServer", "KamiSama.Modules.PolicyEngine.Posgtgresql", "postgresql", "PostgresqlPolicyEngineDbContext", $currentVersion, $nextVersion);
	};
	serviceplan = @{
		Sqlite = [MigrationContext]::New("TestApiServer", "KamiSama.Modules.ServcePlan.Sqlite", "sqlite", "SqliteServicePlanDbContext", $currentVersion, $nextVersion);
		Postgresql = [MigrationContext]::New("TestApiServer", "KamiSama.Modules.ServcePlan.Posgtgresql", "postgresql", "PostgresqlServicePlanDbContext", $currentVersion, $nextVersion);
	};
	ticketing = @{
		Sqlite = [MigrationContext]::New("TestApiServer", "KamiSama.Modules.Ticketing.Sqlite", "sqlite", "SqliteTicketingDbContext", $currentVersion, $nextVersion);
		Postgresql = [MigrationContext]::New("TestApiServer", "KamiSama.Modules.Ticketing.Posgtgresql", "postgresql", "PostgresqlTicketingDbContext", $currentVersion, $nextVersion);
	};
	contents = @{
		Sqlite = [MigrationContext]::New("TestApiServer", "KamiSama.Modules.Contents.Sqlite", "sqlite", "SqliteContentsDbContext", $currentVersion, $nextVersion);
		Postgresql = [MigrationContext]::New("TestApiServer", "KamiSama.Modules.Contents.Posgtgresql", "postgresql", "PostgresqlContentsDbContext", $currentVersion, $nextVersion);
	};
	
};

if ($ProjectName.ToLower() -eq "all")
{
	foreach ($name in $all.Keys)
	{
		.\migrate.ps1 -ProjectName $name -Database $Database
		
	}

	exit 0
}
$project = $all[$ProjectName.ToLower()];

if ($project -eq $null)
{
	Write-Host "Project name: [$ProjectName] is not found"

	exit 1
}

if ($Database.ToLower() -eq "all")
{
	foreach ($dbName in $project.Keys)
	{
		.\migrate.ps1 -ProjectName $ProjectName -Database $dbName
	}

	exit 0
}

$project_with_database = $project[$Database]

if ($project_with_database -eq $null)
{
	Write-Host "Database configuration [$Database] for project name: [$ProjectName] is not found"

	exit 1
}

$project_with_database.RebuildMigrations()
