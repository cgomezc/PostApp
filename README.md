# PostApp
CASH Masters POS Change Calculator - A  C# console application that calculates optimal change for point-of-sale systems, featuring customizable global currency settings

## Features

- **Optimal Change Calculation**: Calculates and returns the minimum number of bills and coins for the given change.
- **Customizable Currency Settings**: Supports global configuration for various countries' denominations.
- **Error Handling**: Error detection and exception handling for edge cases.
- **Comprehensive Unit Tests**: Ensures complete coverage for functionality and edge cases.

## How It Works

1. **Initialization**:
   - Set the default currency denomination globally in the appsettings.json file
![image](https://github.com/user-attachments/assets/4b78a450-6746-4e3f-98c9-cdeddf38c045)


2. **Change Calculation**:
   - Input the price.
   - Input the payment (comma-separated) e.g. ".10,.20, .50, 1.00"
   - The system validates inputs and calculates the optimal change using the global denominations.

3. **Output**:
   - The result is a structured list representing the change.


Build and Run

dotnet build
dotnet run

Run Test

dotnet test


