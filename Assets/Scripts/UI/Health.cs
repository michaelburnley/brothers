public class Health : UIText {
    private void Update() {
        textComponent.text = title + ": " + Globals.Health;
    }
}