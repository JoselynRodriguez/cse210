using System;

public class ChecklistGoal : Goal {
    private int _target;
    private int _bonus;
    private int _amountCompleted;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points) {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent(ref int score) {
        if (_amountCompleted < _target) {
            score += _points;
            _amountCompleted++;
            if (_amountCompleted == _target) {
                score += _bonus;
            }
        }
    }

    public override bool IsComplete() {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString() {
        return $"{_shortName} ({_description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation() {
        return $"ChecklistGoal, {_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
    }
}

