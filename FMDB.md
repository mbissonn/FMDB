# Fake Movie Database

## Tools

### Database: MySQL

    The relational database that the project uses is MySql, constructed using Microsoft SQL Server Management Studio (SSMS). A drop-create-insert script can be found in:
    
        FMDB/Database/dropcreate.sql

    To create the database, please use SSMS and navigate to:

        File > Open > File

    Then, select and open FMDB/Database/dropcreate.sql. Finally, execute the query script. The database should now be set up and populated with 15 movies.

### General Purpose Language: C\#

    The backend is coded in C#, and has the standard controller, DAO, and model organizational scheme.

### IDE: Visual Studio Community 2019

    Visual Studio Community 2019 was used as the IDE within which the backend code was written. In addition to setting up the database, you will need to run the backend server in order to access the user interface. To do so, you will want to open the following directory in Visual Studio Community 2019:

        FMDB/MovieProject

    Once the project is open, you can run the server with the button labelled 'ISS EXPRESS' in the middle toolbar at the top of the window. A browser window should come up with with the following address:

        https://localhost:44388/api/movie

    The backend server should be running now. In order for the server to stay online, you will need to keep that window/tab open.

### API Framework: ASP.NET

    The backend uses the ASP.NET framework as its web framework, allowing for basic API functionality.

### Frontend Framework: BootstrapVue

    The frontend was written in Visual Studio Code, and uses BootstrapVue to construct an intuitively navigable user interface. Once you have the database set up and the backend server running, you will be able to access the user interface through the frontend server. In order to start the frontend server, you can navigate to the following directory in Windows Terminal using a bash profile:

        FMDB/movieprojectfrontend

    Next, you will need to run the following command:

        npm run serve

    Once you see a message indicating that the development server compiled successfully, you will also see a message indicating the address to access it through your browser. Navigate to that address and you should see the completed application.

## Next Steps

    While the site is functional, visually appealing, and feature-complete, much of the code could stand to be refined and simplified. There is a certain lack of elegance in some of the frontend logic that I would like to rectify.

    Ultimately, to achieve this, I will need to gain a better understanding of the BoostrapVue packages and components that are used in the project. Much of the code cleanup that needs to be done is a result of the how newly-acquainted I am with those tools.

    With all that in mind, I believe the most important next steps for this project are to gain a better understanding of BootstrapVue writ-large and to refactor the frontend code accordingly.

### Thank you for taking the time to review my submission.

    If you have any question, please to not hesitate to contact me at mbissonn@gmail.com


