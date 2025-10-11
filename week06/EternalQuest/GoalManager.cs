using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager {
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start() {
        DisplayPlayerInfo();
        bool running = true;
        while (running) {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            switch (choice) {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    public void DisplayPlayerInfo() {
        Console.WriteLine($"\nYou have: {_score} points");
    }

    public void ListGoals() {
        Console.WriteLine("\nThe Goals are:");
        for (int i = 0; i < _goals.Count; i++) {
            string status = _goals[i].IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {_goals[i].GetDetailsString()}");
        }
        DisplayPlayerInfo();
    }

    public void RecordEvent() {
        ListGoals();
        Console.Write("\nWhich goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int index)) {
            index -= 1;
            if (index >= 0 && index < _goals.Count) {
                int before = _score;
                _goals[index].RecordEvent(ref _score);
                int earned = _score - before;
                Console.WriteLine($"🎉 Congratulations! You earned {earned} points.");
                Console.WriteLine($"🏆 You now have {_score} points.");
            } else {
                Console.WriteLine("Invalid goal number.");
            }
        } else {
            Console.WriteLine("Invalid input.");
        }
    }

    public void SaveGoals() {
        using (StreamWriter writer = new StreamWriter("goals.txt")) {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals) {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals() {
        string filename = "goals.txt";
        if (!File.Exists(filename)) {
            Console.WriteLine("No saved goals found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++) {
            string[] parts = lines[i].Split(",");

            string type = parts[0];

            if (type == "SimpleGoal") {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);

                SimpleGoal sg = new SimpleGoal(name, desc, points);
                if (isComplete) sg.RecordEvent(ref _score);
                _goals.Add(sg);
            }
            else if (type == "EternalGoal") {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);

                _goals.Add(new EternalGoal(name, desc, points));
            }
            else if (type == "ChecklistGoal") {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int completed = int.Parse(parts[6]);

                ChecklistGoal cg = new ChecklistGoal(name, desc, points, target, bonus);
                _goals.Add(cg);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    private void CreateGoal() {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create: ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (type) {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for completing it? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }
}
