# Pre-requistes
### Visual Studio IDE
* The project is coded using the Asp.NET Core Framework and hence require that an Visual Studio IDE either [Visual Studio Community 2019](https://visualstudio.microsoft.com/downloads/) or [Visual Studio Community 2022](https://visualstudio.microsoft.com/downloads/) be used to run the project. 
* Do also ensure that with you have selected the '**ASP.NET and Web Development**' workload when installing the IDE.  

### Additional SDKs
The project is coded using the [.NET Core 3.1.415 SDK](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-3.1.415-windows-x64-installer) as it has Long Term Support(LTS) and require the [Asp.NET Core 3.1.21 Runtime](https://dotnet.microsoft.com/download/dotnet/thank-you/runtime-aspnetcore-3.1.21-windows-x64-installer) to run the project.

# Running the Project
1. Open the `2101WebPortal.sln` file with a Visual Studio IDE
<br />![Open Solution Image](https://res.cloudinary.com/dj6afbyih/image/upload/v1637216507/ict1004/odkv89lttlexndkhxexd.jpg)
2. Right-click the Project (`2101WebPortal.csproj`) & Click `Build 2101WebPortal`
<br />![Right Click Build Project](https://res.cloudinary.com/dj6afbyih/image/upload/v1637216507/ict1004/odkv89lttlexndkhxexd.jpg) 
3. Once the Output Console display that there is `0 failed`, Click on the green play icon to Run the project.
<br />![Run Project](https://res.cloudinary.com/dj6afbyih/image/upload/v1637216507/ict1004/odkv89lttlexndkhxexd.jpg)

# Seed Data
Below are some data that have been seeded into the database for demostration purposes

### Admin/Facilitator Accounts
| Role                 | Username    | Password    |
| -------------------- | ----------- | ----------- |
| System Administrator | admin       | P@ssw0rd123 |
| Facilitator          | instructor1 | P@ssw0rd123 |

### Challenges
| Challenge Id | Is Tutorial Challenge |
| ------------ | --------------------- |
| 1            | Yes                   |
| 2            | No                    |
| 3            | No                    |
| 4            | No                    |

### Students
| Student Id | Name                     |
| ---------- | ------------------------ |
| 2001672    | Gerald                   |
| 2001893    | Reuben                   |
| 2000652    | Zhong Yi                 |
| 2002453    | Sneha                    |
| 2000995    | Merrill                  |

### Game Sessions
| Game Session ID | Access Code | Students Permitted                          | Is Active | Challenges |
| --------------- | ----------- | --------------------------------------------| --------- | ---------- |
| 1               | LAB01       | 2001672, 2001893, 2000652, 2002453, 2000995 | Yes       | 1;2;3;4    |
| 2               | LAB02       | 2001672, 2000652                            | No        | 1;2;4      |

# Development Workflow

> + Main branch
>> + Dev branch
>>> Checkout to individual feature branches
>>>> + Work on Feature
>>>> + Commit, push and reference issues
>>>> + Create PR
>>> + Code Review
>>> + Merge PR and handle conflicts
>> + PR to Main for final prototype release
# User Acceptance Testing
The team conducted UAT on the complete system. The state diagram and ise case diagrams has been updated as shown. 

### UAT Test Demo
[![WBTestImagePreview](https://res.cloudinary.com/dc6eqgbc0/image/upload/v1638108311/uat_zkl3v5.png)](https://www.youtube.com/watch?v=kCtZK9qRJxc "ICT2x01 team3-p3 UAT")

# White Box Testing
The team decided to conduct unit testing on the `ChallengeController` class using the built-in testing framework, XUnit offered with Visual Studio IDE. This is because the `ChallengeController` is required to interact with the Database Context class and the Model class to perform create, update and delete operations.

### Unit Test Demo
[![WBTestImagePreview](https://res.cloudinary.com/dj6afbyih/image/upload/v1638017614/ict1004/Screenshot_2021-11-27_at_20.53.09_kdpfxz.png)](https://www.youtube.com/watch?v=X7RzZ7VLnlQ "ICT2X01 P3-3 White Box Testing")

# Updated Diagrams
The team has updated the diagrams from the M2 report.

### Use Case Diagram
![WBTestImagePreview](https://res.cloudinary.com/dc6eqgbc0/image/upload/v1638108353/M2_-_use_case_diagram_llqutc.png)

### Full System State Diagram
![WBTestImagePreview](https://res.cloudinary.com/dc6eqgbc0/image/upload/v1638108358/newest_state_-_Copy_of_Copy_of_Page_1_1_rfu02u.png)

### Unit Test Statistics

### Test Cases
| S/N | Test Name                                                               | Method Being Tested | Expected Outcome |
| L01 | Select facilitator user type | ------------------- | ---------------- |

### Unit Test Cases
![WBTestImagePreview](https://res.cloudinary.com/dc6eqgbc0/image/upload/v1638108863/logintestcase_qczbiz.png)
![WBTestImagePreview](https://res.cloudinary.com/dc6eqgbc0/image/upload/v1638109160/studentplay_x2meji.png)
![WBTestImagePreview](https://res.cloudinary.com/dc6eqgbc0/image/upload/v1638109161/challengemanagement_pklxmw.png)
![WBTestImagePreview](https://res.cloudinary.com/dc6eqgbc0/image/upload/v1638109173/managegamesession_ryiiml.png)
