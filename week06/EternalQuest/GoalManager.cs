using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager {
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start() {
        bool running = true;
        while (running) {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");

            string choice = Console.ReadLine();
            switch (choice) {
                case "1": CreateGoal(); break;
                case "2": RecordEvent(); break;
                case "3": DisplayGoals(); break;
                case "4": DisplayPlayerInfo(); break;
                case "5": SaveGoals(); break;
                case "6": LoadGoals(); break;
                case "7": running = false; break;
            }
        }
    }

    public void DisplayPlayerInfo() {
        Console.WriteLine($"Score: {_score}");
    }

    public void DisplayGoals() {
        for (int i = 0; i < _goals.Count; i++) {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent() {
        DisplayGoals();
        Console.Write("Which goal did you complete? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < _goals.Count) {
            _goals[index].RecordEvent();
        }
    }

    public void SaveGoals() {
        using (StreamWriter writer = new StreamWriter("goals.txt")) {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals) {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals() {
        string[] lines = File.ReadAllLines("goals.txt");
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++) {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] data = parts[1].Split(",");

            switch (type) {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2])) {
                        // manually set _isComplete if needed
                    });
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    break;
                case "ChecklistGoal":
                    ChecklistGoal cg = new ChecklistGoal(data[0], data[1], int.Parse(data[2]),
                                                         int.Parse(data[3]), int.Parse(data[4]));
                    while (cg.IsComplete() == false && cg.GetStringRepresentation().EndsWith(data[5]) == false) {
                        cg.RecordEvent(); // simulate progress
                    }
                    _goals.Add(cg);
                    break;
            }
        }
    }

    private void CreateGoal() {
        Console.WriteLine("Choose type: 1. Simple 2. Eternal 3. Checklist");
        string type = Console.ReadLine();
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Description: "); string desc = Console.ReadLine();
        Console.Write("Points: "); int points = int.Parse(Console.ReadLine());

        switch (type) {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Target count: "); int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus: "); int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
        }
    }
}
