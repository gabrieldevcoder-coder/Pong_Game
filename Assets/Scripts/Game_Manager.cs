using UnityEngine;
using TMPro; // DŮLEŽITÉ: Nutné pro práci s TextMeshPro

public class Game_Manager : MonoBehaviour
{
	// Vaše proměnná, kterou chcete zobrazit (např. skóre, rychlost, směr...)
	public int score_player_1 = 0;
	public int score_player_2 = 0;
	public TMP_Text score_text;

	// Odkaz na komponentu TextMeshPro na tomto objektu

	void Start()
	{
		score_text.text = score_player_1 + " : " + score_player_2;
	}

	void Update()
	{

	}
	public void AddScore(int player)
	{
		if (player == 0)
			score_player_1++;
		else if (player == 1)
			score_player_2++;

		score_text.text = score_player_1 + " : " + score_player_2;
	}
}
