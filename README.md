# ScoutingApp
2017 Scouting Application for Team 1197 Torbots

# Purpose
The purpose of this application is to provide a more effective platform for gathering scouting data.

# Instructions
The project will not find the LWJGL2 library at first.  I have included it at the top level of the git folder.

-----------------------------------------------Setting up LWJGL2-------------------------------------------------

Right click on the project and select 'Properties'.  In the new window click on 'Java Build Path' and you will see that there is a user library defined called 'LWJGL2'.  This is better than setting a hard link in the build path because a user library allows each person to set the path to the library.  Now close this window by clicking cancel becuase we won't have changed anything.  Up on the top select Window->Preferences.  In the Preferences window select Java->Build Path->User Libraries.  There shouldn't be anything here yet.  Click New and type in'LWJGL2'.  Make sure the name matches exactly!  Once you click okay it will show up, click on it and then select 'Add External JARs...".  A browser window will pop up and navigate to (YOUR PROJECT FOLDER)\ScoutingApp\lwjgl-2.9.3\lwjgl-2.9.3\jar\ and add all the .jars in that folder.  Click 'Apply and Close' and you should be all setup.


# Notes
Currently there are just some loose DLL's floating around in the project.  Ideally we will eventually solve this, but
for the short term this is an acceptable solution.  
