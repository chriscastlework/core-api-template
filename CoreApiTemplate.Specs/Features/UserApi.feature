Feature: User Api

    @mytag
    Scenario: Unauthenticated users can not access user
    When the user api is called
    Then the result is unauthorised
    
    @mytag
    Scenario: Authenticated users can view users
        Given user is authenticated
        When the user api is called
        Then the result has user data