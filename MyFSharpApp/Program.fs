// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"
// Define records for NBA statistics
type Coach = {
    Name: string
    FormerPlayer: bool
}

type Stats = {
    Wins: int
    Losses: int
}

type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

// Define NBA teams
let teams = [
    { Name = "Atlanta Hawks"; Coach = { Name = "Quin Snyder"; FormerPlayer = true }; Stats = { Wins = 35; Losses = 40 } }
    { Name = "Boston Celtics"; Coach = { Name = "Joe Mazzulla"; FormerPlayer = false }; Stats = { Wins = 59; Losses = 16 } }
    { Name = "Brooklyn Nets"; Coach = { Name = "Kevin Ollie"; FormerPlayer = false }; Stats = { Wins = 9; Losses = 14 } }
    { Name = "Charlotte Hornets"; Coach = { Name = "Steve Clifford"; FormerPlayer = true }; Stats = { Wins = 18; Losses = 57 } }
    { Name = "Chicago Bulls"; Coach = { Name = "Billy Donovan"; FormerPlayer = true }; Stats = { Wins = 36; Losses = 40 } }
]

// Filter successful teams
let successfulTeams = teams |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

// Calculate success percentage
let successPercentage team =
    let wins = float team.Stats.Wins
    let losses = float team.Stats.Losses
    (wins / (wins + losses)) * 100.0

let successPercentages = teams |> List.map (fun team -> (team.Name, successPercentage team))

// Define discriminated unions for Valentine's Day activities
type Cuisine = Korean | Turkish
type MovieType = Regular | IMAX | DBOX | RegularWithSnacks | IMAXWithSnacks | DBOXWithSnacks
type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of int * float  // Kilometers, fuel cost per km

// Function to calculate the budget for Valentine's Day activities
let calculateBudget (activity: Activity) =
    match activity with
    | BoardGame -> 0
    | Chill -> 0
    | Movie Regular -> 12
    | Movie IMAX -> 17
    | Movie DBOX -> 20
    | Movie _ -> 5  // For other movie types with snacks
    | Restaurant Korean -> 70
    | Restaurant Turkish -> 65
    | LongDrive (kilometers, fuelCostPerKm) -> int (float kilometers * fuelCostPerKm)

// Example usage of calculateBudget function
let budgetForLongDrive = calculateBudget (LongDrive (100, 2.5)) // Example: 100 km at $2.5 per km
printfn "Budget for long drive: $%d" budgetForLongDrive

// Output successful teams and their success percentages
printfn "Successful Teams:"
successfulTeams |> List.iter (fun team -> printfn "%s - Success Percentage: %.2f%%" team.Name (successPercentage team))
