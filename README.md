# WhoAreMyTeammates?

<h1>Intro</h1>
A plugin for SCP: SL that shows the specified Team a list of their teammates on spawn.
Sends a broadcast out to the players on the team containing a list of their fellow players. For SCPs it will show a list of players with their SCP number in parenthesis. In addition there is the option for players to be notified on class change who is in their team.

<h1>Requirements</h1>

This plugin requires [EXILED](https://github.com/Exiled-Team/EXILED/releases "Exiled Releases") `7.2.0`
The Latest Release marked as 7.2.0 will only work on this version
This plugin **WILL NOT WORK** on previous versions

<h2>Default Config Generated</h2>

```yaml
WhoAreMyTeammates:
  is_enabled: true
  # The delay after the round starts before broadcasts will be displayed.
  on_round_delay: 15
  # The delay after a class change before broadcasts will be displayed.
  on_change_delay: 15
  # Sets broadcasts for each class. Use %list% for the player names/SCP names and %count% for number of teammates
  team_broadcasts:
    SCPs:
      is_enabled: true
      class_change_is_enabled: true
      contents: 'Welcome to the<color=red><b> SCP Team.</b></color><color=#00ffff>

        The following SCPs are on this team:

        </color><color=red>%list%</color>'
      alone_contents: '<color=red>Attention - You are the <b>only</b> SCP This game.

        Good Luck.</color>'
      change_class_contents: 'Welcome to the <color=red><b> SCP Team.</b></color><color=#00ffff>

        The following SCPs are on this team:

        </color><color=red>%list%</color>'
      delay: 5
      max_players: -1
      type: Hint
      time: 10
    FoundationForces:
      is_enabled: true
      class_change_is_enabled: true
      contents: 'Welcome to the <color=#808080><b> MTF Team.</b></color><color=#00ffff>

        The following Guards are on this team:

        </color><color=#808080>%list%</color>'
      alone_contents: '<color=#808080>Attention - You are the <b>only</b> Facility Guard this game.

        Good Luck.</color>'
      change_class_contents: 'Welcome to the<color=#808080><b> MTF Team.</b></color><color=#00ffff>

        The following Guards are on this team:

        </color><color=#808080>%list%</color>'
      delay: 0
      max_players: -1
      type: Hint
      time: 10
    Scientists:
      is_enabled: true
      class_change_is_enabled: true
      contents: "Welcome to the<color=yellow><b> Scientist Team.</b></color><color=#00ffff> \nhese are your partners in science:\n</color><color=yellow>%list%</color>"
      alone_contents: '<color=yellow>Attention - You are the <b>only</b> Scientist this game.

        Good Luck.</color>'
      change_class_contents: 'Welcome to the<color=yellow><b> Scientist Team.</b></color><color=#00ffff>

        These are your partners in science:

        </color><color=yellow>%list%</color>'
      delay: 0
      max_players: -1
      type: Hint
      time: 10
    ClassD:
      is_enabled: true
      class_change_is_enabled: true
      contents: 'Welcome to the<color=orange><b> Class D Team.</b></color>

        The following class Ds are on this team:

        <color=orange>%list%</color>'
      alone_contents: '<color=orange>Attention - You are the <b>only</b> Class D Personnel this game.

        Good Luck.</color>'
      change_class_contents: 'Welcome to the<color=orange><b> Class D Team.</b></color>

        The following class Ds are on this team:

        <color=orange>%list%</color>'
      delay: 0
      max_players: -1
      type: Hint
      time: 10
    ChaosInsurgency:
      is_enabled: true
      class_change_is_enabled: true
      contents: 'Welcome to the<color=green><b> Chaos Insurgency.</b></color>

        The following players are your comrades:

        <color=green>%list%</color>'
      alone_contents: '<color=green>Attention - You are the <b>only</b> Insurgent this game.

        Good Luck.</color>'
      change_class_contents: 'Welcome to the<color=green><b> Chaos Insurgency.</b></color>

        The following players are your comrades:

        <color=green>%list%</color>'
      delay: 0
      max_players: -1
      type: Hint
      time: 10
  debug: false
```

