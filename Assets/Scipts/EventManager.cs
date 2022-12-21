using System.Collections.Generic;

public enum EventType
{
    ON_TAKE_DAMAGE = 0,
    ON_PLAYER_DEATH = 1,
    ON_ABILITY_GAIN = 2,
    ON_CHANGE_DIRECTION = 3,
    ON_WALKING = 4,
    ON_PLAYER_ATTACK = 5,
    ON_GIVE_ABILITY = 6,
    ON_HEALTH_GAIN = 7,
}

public static class EventManager
{
    private static Dictionary<EventType, System.Action> eventDictionary = new Dictionary<EventType, System.Action>();

    public static void AddListener(EventType type, System.Action function)
    {
        if (!eventDictionary.ContainsKey(type))
        {
            eventDictionary.Add(type, null);
        }
        eventDictionary[type] += function;
    }

    public static void RemoveListener(EventType type, System.Action function)
    {
        if (eventDictionary.ContainsKey(type) && eventDictionary[type] != null)
        {
            eventDictionary[type] -= function;
        }
    }

    public static void RaiseEvent(EventType type)
    {
        eventDictionary[type]?.Invoke();
    }
}

public static class EventManager<T>
{
    private static Dictionary<EventType, System.Action<T>> eventDictionary = new Dictionary<EventType, System.Action<T>>();

    public static void AddListener(EventType type, System.Action<T> function)
    {
        if (!eventDictionary.ContainsKey(type))
        {
            eventDictionary.Add(type, null);
        }
        eventDictionary[type] += function;
    }

    public static void RemoveListener(EventType type, System.Action<T> function)
    {
        if(eventDictionary.ContainsKey(type) && eventDictionary[type] != null)
        {
            eventDictionary[type] -= function;
        }
    }

    public static void RaiseEvent(EventType type, T arg1)
    {
        eventDictionary[type]?.Invoke(arg1);
    }
}
