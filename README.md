# [Selenium Automation Project](https://www.selenium.dev/documentation/webdriver/ "click on it to navigate")


Ready-to-use UI Test Automation Architecture using Csharp and Selenium WebDriver. 

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/Abhikpt/AutmationProject1/">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>
  <p align="center">
    An basic automation project with basic Selenium and C# code
    <br />
    <a href=""><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="">View Demo</a>

  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>


<!-- ABOUT THE PROJECT -->
## About The Project

The web automation application is developed using Visual Studio Code, utilizing C# as the primary programming language. 
It leverages the NUnit testing framework for writing and executing unit tests, ensuring the reliability and functionality of the application. 
Additionally, Selenium WebDriver is employed for automating web browser interactions, enabling the creation of automated tests for web applications.

I am using application [Swag Labs](https://www.saucedemo.com/) to automate as:

* It is a open source
* Have Login funcationality
* different validation on login funcation

### Built With

1. *[Visual Studio Code (VS Code)](VSCode-url)*:
   - A lightweight yet powerful code editor developed by Microsoft.
   - Provides essential features for coding, debugging, and version control.
   - Supports various programming languages and extensions, making it highly customizable.

2. *[C# Programming Language](Csharp)*:
   - A modern, object-oriented programming language developed by Microsoft.
   - Known for its simplicity, scalability, and extensive standard library.
   - Widely used for building a wide range of applications, including web, desktop, and mobile.

3. *[NUnit Testing Framework]([Nunit-url)*:
   - A popular unit testing framework for the .NET platform.
   - Allows developers to write and execute unit tests for C# applications.
   - Offers features like parameterized tests, test fixtures, and assertions for comprehensive test coverage.

4. *[Selenium WebDriver](selenium-url)*:
   - A powerful tool for automating web browser interactions.
   - Enables developers to create automated tests for web applications.
   - Supports multiple programming languages, including C#, and integrates with popular browsers like Chrome, Firefox, and Safari.

### Purpose:
The web automation application aims to streamline the testing process for web applications by automating repetitive tasks, such as user interactions and validations. By utilizing C#, NUnit, and Selenium WebDriver, developers can ensure the reliability, functionality, and performance of web applications across different browsers and platforms.


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[VSCode-url]: https://code.visualstudio.com/docs/csharp/get-started
[Csharp-url]: https://dotnet.microsoft.com/en-us/learn/csharp
[Nunit-url]: https://docs.nunit.org/
[selenium-url]: https://www.selenium.dev/documentation/webdriver/
[Selenium Automation Project]: https://img.shields.io/badge/Selenium%20Automation%20Project-8A2BE2


## LWASpecflow
### Drivers
- IDriverFactory  -> expose the Driver Property from class DriverFactory.
-DriverFactory -> initalize the Driver object and assign chromebrowesr / remote browser. It consuming the property and value from Testsetting and Config class.
-