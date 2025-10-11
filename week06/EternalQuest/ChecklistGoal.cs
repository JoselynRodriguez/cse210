using System;

public class ChecklistGoal : Goal {
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points) {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent() {
        if (_amountCompleted < _target) {
            _points += _points;
            _amountCompleted++;
            if (_amountCompleted == _target) {
                _points += _bonus;
            }
        }
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString() =>
        $"{_shortName} ({_description}) -- Completed {_amountCompleted}/{_target}";

    public override string GetStringRepresentation() =>
        $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
}
