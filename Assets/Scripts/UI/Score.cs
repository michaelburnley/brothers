public class Score : UIText {
    
    private void Update() {
        textComponent.text = title + ": " + Globals.Score;
    }
}