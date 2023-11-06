Feature: BStackDemo

@Login
Scenario: Login to BStackDemo
	Given Open the Browser
	| Browser | BrowserVersion | OS         |
	| Chrome  | 118            | Windows 10 |
	When Enter the URL
	Then Click on Login