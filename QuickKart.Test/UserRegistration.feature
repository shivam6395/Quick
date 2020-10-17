Feature: UserRegistration
	In order to buy something
	As a customer
	I want to Create my account  into the application so that i can make purchase


Scenario: User Registration
	Given I am on the Registration  page
		And I have entered my EmailId as <emailid>
		And I have entered my User Password as <password>
		And I have entered my Gender as <gender>
		And I have entered my DateOfBirth as <dob>
		And I have entered my Address as <address>
	When I press Register
	Then I should be redirected to the Login page

	Examples: 
	| emailid               | password | gender | dob        | address |
	| Yoshhiiiiii@gmail.com | abc1236  | M      | 06-03-1995 | abc     |
