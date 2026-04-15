Feature: EHU Website Tests

  Scenario: Open About page
    Given user opens EHU homepage
    When user clicks About link
    Then About page should be opened

  Scenario: Search for study programs
    Given user opens EHU homepage
    When user searches for "study programs"
    Then search results page should be shown

  Scenario: Change language to Lithuanian
    Given user opens EHU homepage
    When user changes language to LT
    Then Lithuanian site should be opened

  Scenario: Check contacts page
    Given user opens Contacts page
    Then contact information should be visible