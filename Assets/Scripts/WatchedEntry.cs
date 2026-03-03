// LiveInspectorModels.cs
using System;
using UnityEngine;

namespace LiveInspector
{
    [System.Serializable]
    public class WatchedEntry
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string InspectorPath { get; set; }
        public string ObjectType { get; set; }
        public bool IsEnabled { get; set; } = true;
        public bool IsPaused { get; set; } = false;
        public NotificationSettings Notifications { get; set; } = new NotificationSettings();
    }

    [System.Serializable]
    public class NotificationSettings
    {
        public ConditionType Condition { get; set; } = ConditionType.None;
        public NotificationAction Action { get; set; } = NotificationAction.None;
        public object TargetValue { get; set; }
    }

    public enum ConditionType
    {
        None,
        GreaterThan,
        LessThan,
        Equals,
        Changed
    }

    public enum NotificationAction
    {
        None,
        PlaySound,
        ShowToast,
        LogMessage
    }

    [System.Serializable]
    public class SessionSnapshot
    {
        public string SnapshotId { get; } = Guid.NewGuid().ToString();
        public string Timestamp { get; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        public SerializableFieldItem[] FieldValues { get; set; }
    }

    [System.Serializable]
    public class SerializableFieldItem
    {
        public string Path { get; set; }
        public string ObjectPath { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }

    [System.Serializable]
    public class ValueSnapshot
    {
        public string Timestamp { get; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        public string Value { get; set; }
    }

    [System.Serializable]
    public class ValueHistory
    {
        public string EntryId { get; set; }
        public ValueSnapshot[] Snapshots { get; set; } = new ValueSnapshot[0];
        
        public void AddSnapshot(string value)
        {
            var newSnapshots = new ValueSnapshot[Snapshots.Length + 1];
            Snapshots.CopyTo(newSnapshots, 0);
            newSnapshots[Snapshots.Length] = new ValueSnapshot { Value = value };
            Snapshots = newSnapshots;
        }
    }
}