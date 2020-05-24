# webapi2.net
C# / .Net / .NetFramework / Web API / Web API2

# .NetFrameWork Web Api 2
* Nuget Packges: entityframework, mvc
* Using RoutePrefix and Route data annotations for routing
1. Use IHttpActionResult as return type
2. Web Api 2 features
* Using HttpGet, HttpPost, HttpPut, and HttpDelete data annotations for request types
* Using DAO with LINQ query to interact with database and controller
* Implementing action and exception filters at action and global scope
1. Registering filters in WebApiConfig.cs
* Remove XmlFormatter in WebApiConfig.cs to return only json formatted data to client
* Implementing cors setting
1. install web api cors package
2. if entity framework version is not compatible, downgrade entity framework before installing cors pacakge