using UnityEngine;

public class Target: MonoBehaviour
{
    public Vector2 position;
    private float speed;
    private float radius;
    private Color color;
    private bool moving;

    public Target(Vector2 pos, float spd, float rad = 10f, Color col = default(Color))
    {
        position = pos;
        speed = spd;
        radius = rad;
        color = col == default(Color) ? Color.white : col;
        moving = false;
    }

    public void Render()
    {
        // Placeholder for your rendering logic in Unity
        // Use Unity's graphics system to draw circles or other shapes

        // Example of rendering a circle sprite:
        GameObject circle = new GameObject();
        circle.transform.position = new Vector3(position.x, position.y, 0);
        SpriteRenderer renderer = circle.AddComponent<SpriteRenderer>();
        renderer.sprite = Resources.Load<Sprite>("CircleSprite"); // Replace with your circle sprite

        // Set color based on moving status
        renderer.color = moving ? Color.green : Color.red;
    }

    public void Move(Vector2 targetLoc, float ticks)
    {
        float distPerTick = speed * ticks / 1000f;

        if (Mathf.Abs(position.x - targetLoc.x) <= distPerTick
            && Mathf.Abs(position.y - targetLoc.y) <= distPerTick)
        {
            moving = false;
            color = Color.red;
        }
        else
        {
            moving = true;
            color = Color.green;
            Vector2 currentVector = position;
            Vector2 newVector = targetLoc;
            Vector2 towards = (newVector - currentVector).normalized;

            position.x += towards.x * distPerTick;
            position.y += towards.y * distPerTick;
        }
    }
}
