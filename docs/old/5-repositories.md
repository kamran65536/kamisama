# 5. KamiSama.Repsitories Libraries
This set of libraries provide the most simple but repeated functionality for repository pattern in DDD.
## 5.1. KamiSama.Repositories.Core
The library provides different interfaces for different usages:
- **IRespository:** simple Add/Delete/Update/Find functionality.
- **IQueryableRepository:** adds Where functionality to IRepository.
- **IAsyncRepository:** same as IRepository but async.
- **IAsyncQueryableRepository:** same as IQueryableRepository but async.
Also there is a default in-memory repostory implementation named InMemoryRepsitory. Good news is that it is thread safe. You can use this for simple testing.
## 5.2. KamiSama.Repositories.EntityFramework
This library provides implementation of the interfaces in [KamiSama.Repositories.Core](#51-kamisamarepositoriescore) for Entity Framework (6.4+).
## 5.3. KamiSama.Repositories.EntityFrameworkCore
This library provides implementation of the interfaces in [KamiSama.Repositories.Core](#51-kamisamarepositoriescore) for Entity Framework Core (3.1.2+).