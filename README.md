# Goals for this project

- Create a small eCommerce store that's "whitelabeled" and unbranded -- the templates are not specific to any one business or type of product. 
- Business owners should be able to use this project to create their own online store by configuring it (via some kind of menu or options page) with their own brand name, logo, domain, etc. 
- Owners should be able to upload their products with custom prices, images, descriptions, etc. 
    - The products should support multiple different options/"variants" -- think Shopify variants. 
- Customers should be able to purchase the items via credit card (stripe API key required) 
- The store should also support a small blogging platform with markdown blog posts. 
    - Owners should be able to configure the paths of their blog, e.g. /blog/{{post}} or /cool-stuff/blog/{{post}}.
- The store admin should have an area that lets store owners add arbitrary links to the navbar/footer. 
- The store should have a sitemap that includes all products, blog posts and arbitrary links. 
- The store should have some kind of admin dashboard that tracks orders. 
- The store should support multiple owner users. 
- The store should send emails when an order is received. 
    - Send emails to the customers. 
    - Send emails to the store owner and their team. 
- The store admin dashboard should have a method for shipping an order. 
    - The store should send emails when an order has been shipped. 
- Owners should be able to upload their own custom CSS stylesheets. 
