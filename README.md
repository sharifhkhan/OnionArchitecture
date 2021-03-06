## Onion Architecture on .NET (Ports and Adapters)

This template was made based on [Tony Sneed's Peeling Back the Onion Architecture](https://blog.tonysneed.com/2011/10/08/peeling-back-the-onion-architecture/) 

## REST api calls: 

`localhost:{port}/api/products`

`localhost:{port}/api/categories`

`localhost:{port}/api/categories/{productId}/products`

## Technology overview:

- Specflow
- NUnit
- Moq <br>
- Entity Framework Code First
- MVC4 Web API
- Ninject
- JSON.NET

## Archive notes:

I created and used this architecture to design the original [Foodsby](https://www.foodsby.com) ecommerce platform.
