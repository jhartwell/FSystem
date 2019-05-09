FSystem
---

Pre-reqs
---
.NET Core 2.2

Notes
---

Because Web API uses HTTPS by default, in order to ensure that there are no issues running
the project locally I have disabled HTTPS. There are times that certs are invalid
and that causes the project not to load properly. It is not worth the time right now
to invest in getting the certs running.

Projects
----

  * FSystem.Common.Interfaces -> This is where all of the interfaces used by the
 system are stored
  
  * FSystem.Common -> This is where the implementations of the 
  FSystem.Common.Interfaces are stored
  
  * FSystem.Api -> This is the Web API project that houses the actual web app
  
  * FSystem.Tests.Shared -> This is data that is shared between all test projects
  
  * FSystem.Common.Tests -> This is where all tests related to the FSystem.Common
  project are located
  
  * FSystem.Api.Tests -> This is integration tests that ensure the Web API is working
  
  Ways to Improve
  ---
  
  Right now, everything takes the "happy path". Error handling is minimal and needs
  to be added. 
