# HDNUG Website
The website for the Houston Dot Net User Group.

Established in 2001, the Houston Dot Net User Group was organized to explore, examine, develop and advance applications and services 
built with the .NET Development platform, and aid the widespread learning and sharing of the .NET development platform in 
the Houston technology market place with our members, who are both individuals and corporations.

To this end, HDNUG created a website some time ago. The primary purpose of the website was to keep the usergroup's members informed about 
upcoming meetings and events. Although the website continues to meet this purpose, it is rather dated and lacks social media presence. 
That said, HDNUG has embarked on a new project to create a new website for the usergroup's members.

The new website is an Asp.NET MVC web application.

The goals of the new website:
* Modernize UI
* Link to HDNUG social media accounts
* Provide advertisment/slide rotation to homepage
* Improve mailing list signup and management
* Provide comments feed to meeting posts

## Directory Structure
The repository consists of the following directories:
* Hdnug.Domain - Contains the domain objects and data access components
* Hdnug.Web.Tests - Contains unit tests for services contained in the web project
* Hdnug.Web - Contains the web application. The web application contains directories organized using the MVC convention. The site is 
split between the customer facing website and an area for site administration.
* HdnugAnnouncementFormatter - A tactical solution for the current application to create meeting announcements.

## Getting Started
The site is being developed using Visual Studio 2015 Community Edition and SQL Server Express 2014. To get started, simply clone the 
repository and build the application. The application is configured to create and seed the database. As an alternative, you can run the 
EF Code First **Update-Database** command against the Hdnug.Domain project from the package manager console.

## Workflow
To contribute to the project, please fork & pull to be added to the contributor list. From there, contributors will create feature branches 
and send pull requests based on existing issues.

Pull requests for any improvements or enhancements with no issues are welcome.

