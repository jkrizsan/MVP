# MVP

This is an Asp.Net Core endpoint for create order and invoice with data base first approach.

Projects:

MVP.Data: Data layer, represent data structure that store in Database.
MVP.Service: Service layer, handle data acces between data base and other projects
MVP.InitializeDataBase: Console Application for initialize Database with basic Country and Product data. It is enough to run just once.
MVP.Test: test project, there are some unit and function tests for Controller layer and for Helpers
MVP.API: the endpont of api, there is a controller class that receive messeges and answer after parsing data.
There is also some Helper classes that help to parse receive datas and to create the invoice.
