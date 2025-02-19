# Lab 4 Summary

In Lab 4, we explored several important libraries in ASP.NET that facilitate backend usage.

## Database Approaches
We were introduced to two main approaches for dealing with databases:
- **Code-First Approach**
- **Database-First Approach**

During the lab, I used both approaches and encountered multiple issues. One of the challenges was setting up multiple DB contexts in the same project. This can be resolved by specifying a single context when executing migration commands.

## AutoMapper
We learned about **AutoMapper**, a class in ASP.NET that allows mapping between different object types. AutoMapper is beneficial for:
- **Security**
- **Interoperability**
- **Separation of Concerns** between application layers

AutoMapper is typically used to map a **ViewModel** to its corresponding entity (e.g., `Student => StudentViewModel`). Developers can also specify which attributes to map. A common mistake I encountered was mapping a `List<StudentViewModel>` to a `List<Student>`, using explicit mapping. However, AutoMapper automatically maps **List to List** when the base type mapping is defined.

## OData (Open Data Protocol)
Finally, we were introduced to **OData** and its benefits. OData is useful for:
- **Filtering**
- **Aggregation**
- **Counting**
- **Other Query Operations**

It provides a flexible way to query data and reduces the need for custom API endpoints.

