// This script will be responsible for the first general KC: Finding an object you've interacted w 5 times
// Ideal way for this to work: there's a separate function (possibly in ClickableItems.cs) for the Find knowledge check. it gets called in the if clause of ChangeKnowledgeLevel accordingly
// This function needs to trigger the 'presence' of a character in the map scene, and they'll have an indication to interact w them
// The user must click them to really begin the KC. So maybe we should have two functions: one to populate the NPC, that begins the KC upon clicking the NPC
// The NPC will ask "Find (object)", and once they back out of the interaction, they must find the object within x amount of time (hidden to the user). If they do,
// increase KC and reward them. If not, reset interaction count of object and KC remains at 1.

// have characters in scenes ask about objects that the user has never interacted with before
// have some sort of section for silhouettes of all the objects in the game that eventually get populated; incentive for them to click
// incentive for knowledge assessments: character interactions that require you to identify x items in order to
// each page in the inventory has a character with associated items for them to click on and eventually unlock the character
// once you click on all items once associated with a specific character it unlocks the character which then allows you to complete a knowledge assessment of those items to accomplish X (baking a pie, etc.)
// get all the scenes created
// make a skeleton of the inventory scene
// maybe check out fungus?