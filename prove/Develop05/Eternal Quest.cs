public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public virtual int GetPoints()
    {
        return _points;
    }

    public abstract string Output();

    public abstract string GetStringRepresentation();
}

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points): base(name, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int points, bool isComplete): base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public void CompleteGoal()
    {
        _isComplete = true;
    }

    public bool IsComplete()
    {
        return _isComplete;
    }

    public override string Output()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {GetName()} ({GetDescription()})";
    }

    public override string GetStringRepresentation()
    {
        return $"Simple|{GetName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override string Output()
    {
        return $"[Repeatable] {GetName()} ({GetDescription()})";
    }

    public override string GetStringRepresentation()
    {
        return $"Eternal|{GetName()}|{GetDescription()}|{GetPoints()}";
    }
}

public class ListGoal : Goal
{
    private int _amountCompleted;
    private int _targetAmount;
    private int _bonus;

    public ListGoal(string name,string description,int points,int targetAmount,int bonus): base(name, description, points)
    {
        _amountCompleted = 0;
        _targetAmount = targetAmount;
        _bonus = bonus;
    }

    public ListGoal(string name,string description,int points,int targetAmount,int bonus, int amountCompleted): base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _targetAmount = targetAmount;
        _bonus = bonus;
    }

    public void RecordProgress()
    {
        if (_amountCompleted < _targetAmount)
        {
            _amountCompleted+=1;
        }
    }

    public bool IsComplete()
    {
        return _amountCompleted >= _targetAmount;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public int GetTargetAmount()
    {
        return _targetAmount;
    }

    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public override string Output()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetName()} ({GetDescription()}) -- " + $"Completed {_amountCompleted}/{_targetAmount} times";
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist|{GetName()}|{GetDescription()}|" + $"{GetPoints()}|{_targetAmount}|{_bonus}|" + $"{_amountCompleted}";
    }
}