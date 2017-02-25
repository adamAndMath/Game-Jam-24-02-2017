using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waypoints : MonoBehaviour
{
    public static Waypoints Instance { get; private set; }

    public Transform canvas;
    public Player playerPrefab;
    public List<Transform> points;
    public List<Color> colors;
    public List<PartMove> partMoves;
    public List<PartWeapon> partWeapons;
    public HealthBar[] bars;
    public GameObject[] countDown;
    public float time = 5;

    private List<int> avalable;
    private List<Player> players = new List<Player>();
    private float timer;
    private int id = -1;
    private State state = State.Idle;

    private enum State
    {
        Idle, Starting, Game, Ending
    }

    void Awake()
    {
        Instance = this;
        avalable = new List<int>();
        timer = time;

        for (int i = 0; i < colors.Count; i++)
            avalable.Add(i);
    }

    public void StartGame()
    {
        state = State.Starting;
        Update();
    }

    void Update()
    {
        switch (state)
        {
            case State.Starting:
                StartingGame();
                break;
            case State.Game:
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i]) continue;
                    players.RemoveAt(i--);
                }

                if (players.Count <= 1)
                {
                    timer = 3;
                    state = State.Ending;
                }
                break;
            case State.Ending:
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i]) continue;
                    players.RemoveAt(i--);
                }

                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    SceneSellecter.winners.Add(players.Count == 0 ? new Color(0.5F, 0.5F, 0.5F, 1) : players[0].GetComponent<SpriteRenderer>().color);
                    SceneManager.LoadScene(0);
                }
                break;
        }
    }

    private void StartingGame()
    {
        for (int i = 0; i < avalable.Count; i++)
        {
            if (!Input.GetButtonDown(avalable[i] + playerPrefab.pickUp)) continue;
            AddPlayer(avalable[i]);
            avalable.RemoveAt(i--);
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = time;
            if (id >= 0)
                countDown[id].SetActive(false);

            if (++id < countDown.Length)
                countDown[id].SetActive(true);
            else
            {
                foreach (Player player in players)
                {
                    player.enabled = true;
                }

                state = State.Game;
            }
        }
    }

    private void AddPlayer(int id)
    {
        int posID = Random.Range(0, points.Count);
        int colorID = Random.Range(0, colors.Count);
        int moveID = Random.Range(0, partMoves.Count);
        int weaponID = Random.Range(0, partWeapons.Count);

        Player player = Instantiate(playerPrefab);
        player.enabled = false;
        player.id = id;
        player.transform.position = points[posID].position;
        player.GetComponent<SpriteRenderer>().color = colors[colorID];
        player.PartMove = Instantiate(partMoves[moveID]);
        player.PartWeapon = Instantiate(partWeapons[weaponID]);

        foreach (HealthBar bar in bars)
            Instantiate(bar, canvas).player = player;

        points.RemoveAt(posID);
        colors.RemoveAt(colorID);
        players.Add(player);
    }
}
