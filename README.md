# GymMembershipManagementSystem

A Windows Forms application built with C# for managing gym memberships, tracking member payments, and generating insightful reports. This project provides a user-friendly interface for administrators to handle member data, view payment histories, and analyze monthly incomes via graphical representations.

## Features

- **Member Management:**  
  Add, update, and remove members with details such as name, contact info, birthdate, and membership type.
  
- **Payment Tracking:**  
  Record and update membership fees. Monitor members’ payment status, identify unpaid fees, and send timely reminders.

- **Reporting & Analytics:**  
  Visualize monthly income trends with charts, and generate detailed reports on payment compliance and membership growth.

- **Secure Access:**  
  Admin login ensures only authorized personnel can manage the data.

## Technologies Used

- **Language:** C#
- **Framework:** .NET Framework (Windows Forms)
- **Database:** SQLite
- **IDE:** JetBrains Rider (can also be opened with Visual Studio)

## Project Structure

- **GymMembershipManagementSystem (UI):**  
  Windows Forms application handling user interaction, data display, and navigation between forms.
  
- **GymMembershipManagementSystem.BLL (Business Logic Layer):**  
  Implements core functionality and business rules, acting as the intermediary between UI and DAL.
  
- **GymMembershipManagementSystem.DAL (Data Access Layer):**  
  Interacts with the SQLite database, performing CRUD operations on members and payments.
  
- **GymMembershipManagementSystem.Models (Entities):**  
  Defines data structures for members, payments, and administrators.

## Getting Started

### Prerequisites

- .NET Framework 4.8 (or compatible)
- SQLite
- JetBrains Rider or Visual Studio

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your_username/GymMembershipManagementSystem.git
