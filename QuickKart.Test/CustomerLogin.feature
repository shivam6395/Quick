Feature: CustomerLogin
	In order to buy something
	As a customer
	I want to Login into the application so i can make purchase


Scenario: Customer Login
	Given I am on the login page
		And I have entered my username as <username>
		And I have entered my password as <password>
	When I press login
	Then the i should see the customers page
	Examples: 
	| username        | password   |
	| Yoshi@gmail.com | RICAR@1234 |

Scenario: Admin Login
	Given I am on the  page
		And I have  my username as <username>
		And I have  my password as <password>
	When I  login
	Then the i  see the customers page
	Examples: 
	| username        | password   |
	| Yoshi@gmail.com | RICAR@1234 |


#Scenario: Customer Login failed when incorrect details are provided
#	Given I am on the login page
#		And I have entered my Credentials
#			| Username   | Password |
#			| testuser_1 | Test@123 |
#	When I press login
#	Then the i should not able see the customers page