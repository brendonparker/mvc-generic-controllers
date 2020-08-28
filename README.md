# mvc-generic-controllers
Sample implementation of a basic pluggable MVC site using generic controllers

Inspired by Filip W.: https://www.strathweb.com/2018/04/generic-and-dynamically-generated-controllers-in-asp-net-core-mvc/

I was curious to see if I could take it further by adapting it for MVC, and dynamically generating the UI as well. Just a proof-of-concept. There are plently of SOLID viloations, namely, I have a classes that are concertned with everything from the database all the way through to the UI/navigation. Using automapper, or adding in some better adapter patterns would be ideal if this were production bound.

For now, using EntityFramework as a backing storage. The pros of that would be easy searching/sorting if those feature are added later. The cons are that you have to manage the objects in the DbContext (i.e. any new objects need to be added as a `DbSet<>`) and any changes to your objects require changes to the database. For this reason, a document database may make more sense. I'm interested to eventually move it to dynamodb.

## Known Weaknesses
There are plenty of limitations...
- Everything requires a Guid as the PK
- No support for parent-child relationships (yet)


This may continue to evolve.