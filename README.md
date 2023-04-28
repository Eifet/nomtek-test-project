# nomtek-test-project

Link to the task description: https://nomtek.notion.site/Unity-Test-Project-1f78c86965c04955b8d082862e689766

The target project resolution is 1920:1080.

Main assemblies:
- Gameplay - main assembly for all gameplay related folders.
- Gameplay/_Gameplay - kind of a core assembly with scene assets and base scripts. Would be better to create Core assembly for it, but I was kinda having hangover, while writing all of it, so I've left it as is.
- Gameplay/GameplayFlow - a super dummy implementation of FSM with Initial, Game, End states.
- Gameplay/Item - assembly that contains everything about the item setup (prefabs, SOs, materials). Item has two prefabs. One for placement with the mouse and the other for actually interacting on stage when the item is placed. (placement prefab and stage prefab)
- Gameplay/StageItem - assembly that is responsible for instantiating items and managing instantiated items
- Ui - for all Ui/Canvas/Views related stuff.
