# EliteThreads

EliteThreads is a comprehensive e-commerce web application that simulates an online clothing store. The project utilizes a microservices architecture, with the frontend built using Angular and the backend implemented as a set of ASP.NET Core microservices. The application leverages various technologies, including RabbitMQ for asynchronous messaging, Auth0 for user authentication, and Stripe for secure payment processing.

## Project Overview

EliteThreads is designed to provide a seamless and feature-rich shopping experience for customers. The key features of the application include:

- **Product Catalog**: Customers can browse a catalog of clothing items, view detailed product information, and add items to their shopping cart.
- **Review and Rating System**: Customers can write reviews and rate the products they have purchased, allowing other users to make informed decisions.
- **User Accounts**: Customers can create accounts, manage their profile information, and view their order history.
- **Shopping Cart and Wishlist**: Customers can add items to their shopping cart, save items to a wishlist for later, and proceed to checkout.
- **Secure Payments**: Customers can securely complete their purchases using the Stripe payment gateway.
- **Microservices Architecture**: The backend of the application is built using a microservices approach, with individual services responsible for different functionalities, such as product management, user management, and order processing.

It's worth noting that in a typical microservices-based architecture, each microservice would be a separate solution partitioned into multiple libraries using the clean architecture approach, as demonstrated in the [MilestoneMotorsWebApp](https://github.com/japundzasergej/MilestoneMotorsWebApp) project.

## Technologies Used

- **Frontend**: Angular SPA (Single Page Application) - [EliteThreadsWebApp.Frontend](https://github.com/japundzasergej/EliteThreadsWebApp.Frontend)
- **Backend**: ASP.NET Core Microservices
- **Messaging**: RabbitMQ for asynchronous communication between microservices
- **Authentication**: Auth0 for user authentication and authorization
- **Payments**: Stripe for secure payment processing
- **Database**: Entity Framework Core for data access and database management
- **Clean Architecture**: The microservices follow the principles of clean architecture, with a clear separation of concerns between layers.

## Demo Video
You can watch a demo video of the EliteThreads application on [YouTube](https://www.youtube.com/watch?v=bP8sL6WvRb4&feature=youtu.be). (I can pull up the site on localhost upon reviewer's request as hosting the site externally free of charge proved quite a challenge.)

