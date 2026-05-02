# Goalkeeper - System Context Diagram

```mermaid
C4Context
  title System Context Diagram for Goalkeeper

  Person(user, "User", "Web user")

  System(goalkeeper, "GoalKeeper", "Allows users to view information about the Jupiler Pro League")

  Rel(user, goalkeeper, "Views information about the Jupiler Pro League")
```
