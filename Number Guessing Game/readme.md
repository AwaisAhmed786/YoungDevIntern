Ensure Correct Project Type
Make sure you have selected the correct project type. You need to create a "Windows Forms App (.NET Framework)" project, not a ".NET Core" or ".NET 5/6" project.

Step-by-Step Instructions
1. Open Visual Studio
Launch Visual Studio from your Start menu or desktop.
2. Create a New Project
Click on Create a new project.
Search for Windows Forms App (.NET Framework) in the search bar.
Select Windows Forms App (.NET Framework) from the list.
Click Next.
3. Configure Your New Project
Name your project: NumberGuessingGame.
Choose a location: Select a directory where you want to save your project.
Solution name: You can keep it the same as your project name.
Click Create.
4. Verify Your Project Setup
Ensure that your project has references to System.Windows.Forms.
Add Missing References
1. Adding System.Windows.Forms Reference
Right-click on your project in the Solution Explorer.
Select Add > Reference....
In the Reference Manager, check System.Windows.Forms under Assemblies > Framework.
Click OK.
2. Installing Newtonsoft.Json via NuGet
Right-click on your project in the Solution Explorer.
Select Manage NuGet Packages.
Search for Newtonsoft.Json.
Click Install to add it to your project.
