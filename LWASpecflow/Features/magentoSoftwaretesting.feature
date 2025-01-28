Feature: validate the rating and price for men tees

list all the tess that is having rating icon is 4 star 
Verify the pricees of tees for which rating is 4
list all the tess that is having review count is 4  


@menteesPage
Scenario: list all the tess that is having rating icon is 4 star
    Given chrome browser is open
    When  user pass the URL
    Then user is able to see heading "Home Page"
    When user click on Men top tees
    Then Able to see heading "Tees" and verbiage "Home > Men > Tops > Tees"
    And User is able to see 4 products of rating 4
    And Price of 1st product having rating 4 is $39.00
	
