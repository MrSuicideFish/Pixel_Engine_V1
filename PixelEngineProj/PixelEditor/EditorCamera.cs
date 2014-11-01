using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;

namespace PixelEditor {
    public class EditorCamera : SFML.Graphics.View {
        public float cameraSpeed = 200;
        public int turbo = 1;
        public EditorCamera(FloatRect viewRect) : base(viewRect) { }
        private static int zoomState = 0;

        /// <summary>
        /// PRIVATE VARIABLES
        /// </summary>
        private bool bMoving = false;

        Vector2i initMousePos;
        Vector2i curMousePos;
        Vector2f initCenter;
        public void Update() {
            turbo = !SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.LShift) ? 1 : 3;
            if (SFML.Window.Mouse.IsButtonPressed(Mouse.Button.Middle)) {
                if (!bMoving) {
                    //Get the initial mouse world position
                    initMousePos = Form1.mouseScreenPos;
                    initCenter = Center;
                    bMoving = true;
                } else {
                    //Get the current mouse world position
                    curMousePos = Form1.mouseScreenPos;
                }
                //add the difference to the camera world position
                Vector2f newPos = new Vector2f(curMousePos.X, curMousePos.Y) - new Vector2f(initMousePos.X, initMousePos.Y);
                Center = initCenter + -newPos;

            } else if (!SFML.Window.Mouse.IsButtonPressed(Mouse.Button.Middle)) {
                bMoving = false;
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.W)) {
                Move(new Vector2f(0, (float)(-cameraSpeed * turbo * Editor.deltaTime)));
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.S)) {
                Move(new Vector2f(0, (float)(cameraSpeed * turbo * Editor.deltaTime)));
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.A)) {
                Move(new Vector2f((float)(-cameraSpeed * turbo * Editor.deltaTime), 0));
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.D)) {
                Move(new Vector2f((float)(cameraSpeed * turbo * Editor.deltaTime), 0));
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.R)) {
                Rotate(0.05f);
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.Q)) {
                Rotate(-0.05f);
            }
        }

        //Zoom the camea
        public void SetZoomState(float factor) {
            if (zoomState == -6 && factor == 0.9f) {
                zoomState++;
            }
            if (zoomState == 6 && factor == 1.1f) {
                zoomState--;
            }
            if (zoomState >= -5 && zoomState <= 5) {
                Zoom(factor);
                zoomState = (factor > 1.0) ? zoomState - 1 : zoomState + 1;
            }
            return;
        }
    }
}
