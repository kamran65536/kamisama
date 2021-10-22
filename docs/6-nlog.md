# 6. KamiSama.Extensions.NLog
This library adds some useful functionality to the popular logging library: [NLog](https://nlog-project.org/).
## 6.1. PersianDateLayoutRenderer
Just register the extension to your NLog.config file and use it!
```xml
<nlog>
    <extensions>
        <add assembly="KamiSama.Extensions.NLog" />
    </extensions>
    <targets>
        <target xsi:type="File" name="file" fileName="${baseDir}/now.log" layout="${persian-date} ${message}" />
    </targets>
    <rules>
        <logger name="*" minlevel="Trace" writeTo="file" />
    </rules>
</nlog>
```
## 6.2. EncryptedZipArchiveFileCompressor
Inspired by NLog internal archive file compressor, EncryptedZipArchiveFileCompressor helps you add password to the archive file.
As standard System.IO.Compression.ZipFile does not support zip file password, I used [DotNetZip](https://github.com/haf/DotNetZip.Semverd) to do so.
In order to prevent saving plain passwords in NLog.config file, you should change the nlog default file archive compressor programatically:
```csharp
public class Program
{
    public static void Main(string[] args)
    {
        NLog.Targets.FileTarget.FileCompressor = new EncryptedZipArchiveFileCompressor((fileName, archiveName) => "s0mEp@sswoRD");
	}
}
```