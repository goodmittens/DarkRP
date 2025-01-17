using System;

namespace GameSystems.Player{
  public enum PermissionLevel {
    User,
    Moderator,
    Admin,
    SuperAdmin,
    Developer
  }
  public class UserGroup : IComparable<UserGroup> {
    /// <summary>
    /// The name of the user group. This cannot contain spaces or special characters.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The display name of the user group.
    /// </summary>
    public string DisplayName { get; set; }
    
    public PermissionLevel PermissionLevel { get; set; }

    public Color Color { get; set; }

    public UserGroup(string name, string displayName, PermissionLevel permissionLevel, Color color) {
      // No real reason. Just keeps it clean.
      if ( name.Contains(" ") ) {
        throw new ArgumentException("User group name cannot contain spaces.");
      }
      Name = name;
      DisplayName = displayName;
      PermissionLevel = permissionLevel;
      Color = color;
      Log.Info($"User group {DisplayName} created with permission level {PermissionLevel}.");
    }

    // Implement the CompareTo method
    public int CompareTo(UserGroup other)
    {
        if (other == null) return 1;

        // Compare based on PermissionLevel
        return PermissionLevel.CompareTo(other.PermissionLevel);
    }
  }
}