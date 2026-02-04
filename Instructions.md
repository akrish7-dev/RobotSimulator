## Setup (First Time)

1. Clone or download this repository
2. Ensure .NET 8.0 SDK is installed: `dotnet --version`

## Run the Application

### Interactive Mode
```bash
dotnet run --project RobotSimulator
```

Type commands one at a time:
```
> PLACE 0,0,NORTH
> MOVE
> REPORT
0,1,NORTH
> EXIT
```

### File Mode
```bash
dotnet run --project RobotSimulator localfilepath/commands.txt
```

## Sample Commands

```
PLACE 0,0,NORTH    # Place robot at origin facing north
MOVE               # Move forward one unit
LEFT               # Rotate 90 degree left
RIGHT              # Rotate 90 degree right
REPORT             # Display current position
```
