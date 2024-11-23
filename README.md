# Crayon

## TECHNICAL EXCERCISE TASK
- It is stated in the task that the SQL is to be used, however for the purpose of coding excercise, I've used models and static data mock it. This I decided, since it would take too much to make sql server instance and the model it. My SQL experience is fair, since I used Microsoft SQL for significant part of my career, so I'm open for questions on that part of course.
- On security subject, I've handled it with local jwt tokens created using dotnet user-jwts tool
- ![image](https://github.com/user-attachments/assets/6645a8dc-faa1-4df8-a1c1-79b068c65800)


## SYSTEM DESIGN TASK

### Technologies:
- Relational database to store the data (e.g. Azure SQL)
- Azure Functions to define the api calls.
- Azure Api Management to expose the apis which can be used by Crayon's web app for direct communication with customers or re-selleer to incorporate it in it's own system.
- Azure App Service to host the Web portal for the usage of direct customers. Web portal to be developed with any web development framework. 

### Data Model
![image](https://github.com/user-attachments/assets/e5dadf99-0c7f-4b75-8329-e4b5eb2584a1)

### Services

Create account
![image](https://github.com/user-attachments/assets/563ca670-febd-4095-8a81-a14ac781b5f8)

Register user
![image](https://github.com/user-attachments/assets/21513871-da18-4222-8e45-d88de809e9cd)

Get available software services
![image](https://github.com/user-attachments/assets/91475751-925e-4926-9841-9255f4a5fd04)

Order services for an account
![image](https://github.com/user-attachments/assets/c62176d5-bcd2-499b-b972-48af47e969de)

Get invoice info
![image](https://github.com/user-attachments/assets/f7abce0c-42c5-4da1-91f9-e01801100dd3)

Download billing info
![image](https://github.com/user-attachments/assets/b8308484-bae4-47a4-a356-4aa9d4c02b0b)

Submit support case
![image](https://github.com/user-attachments/assets/063999d6-2387-44ac-86b5-c9bfd9fee22a)
