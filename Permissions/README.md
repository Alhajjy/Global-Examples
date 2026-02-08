# Bitwise Permission System in C#

A clean and efficient demonstration of managing user permissions using **Bitwise Operators** in C#.  
This project illustrates how multiple access levels can be stored and manipulated within a single enumeration value.

---

## 🚀 Overview

In many applications, managing complex user roles and permissions can become cumbersome.  
This project showcases the **Flag-based Permission** approach, which is:

- **Memory Efficient**: Multiple permissions are stored in a single integer.
- **Fast**: Operations use low-level bitwise logic.
- **Scalable**: Easy to add, remove, or check for specific access rights.

---

## 🛠️ Technical Concepts

The project utilizes several bitwise operations to handle permission logic:

- **OR (`|`)**: Combine or add permissions.
- **AND (`&`)**: Check whether a specific permission exists.
- **NOT (`~`)**: Used with AND to remove a permission.

### Example Logic

```csharp
// Adding a permission
_Permissions |= permissionToAdd;

// Checking a permission
bool hasAccess = (_Permissions & permissionToCheck) == permissionToCheck;

// Removing a permission
_Permissions &= ~permissionToRemove;
```

## 📋 Features

### Dynamic Permission Management
Add or remove permissions at runtime.

### User Simulation
Simple console-based login simulation for predefined users:

- Ahmad
- Ali
- Omar

### Enum Flags
Uses an enumeration with powers of two (`2^0`, `2^1`, `2^2`, ...) to guarantee unique bit positions.

---

## 💻 How to Run

1. Clone the repository.
2. Open the project in **Visual Studio** or any C#-supported IDE.
3. Run the application.
4. Enter one of the predefined usernames to inspect permissions:

   - **Ahmad** → Admin & User Management  
   - **Ali** → Client Management
