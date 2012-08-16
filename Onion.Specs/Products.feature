Feature: View Products by Categories
	In order to decide which products to buy
	As a shopper
	I want to see a list of product from a cetegory

@mytag
Scenario: See list of products by category
	Given I have selected a category
	When I press show products
	Then the result should be a list of products for selected category
