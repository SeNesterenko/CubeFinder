using StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private Button _buttonContinue;
        [SerializeField] private Button _buttonRestart;
    
        [SerializeField] private ParticleSystem _winEffect;
    
        private static readonly Vector3 DefaultButtonRestartPosition = new(-100f, -120f, 0);
        private static readonly Vector3 AloneButtonRestartPosition = new(0f, -120f, 0);
        
        private static readonly Vector3 ScaleWonNode = new(0.5f, 0.5f, 1f);
        private static readonly Vector2 RectScaleWonNode = new(600f, 400f);
        private static readonly Vector3 PositionWonNode = new(0f, 80f, 0f);

        public GameNode Initialize(IStateContext gameMap, Transform gameOverScreen)
        {
            var rectTransform = _buttonRestart.gameObject.GetComponent<RectTransform>();
            ReloadButtonPositions(rectTransform);

            if (gameMap.CurrentQuantityNodes >= gameMap.MaxQuantityNodes)
            {
                _buttonContinue.gameObject.SetActive(false);
                rectTransform.localPosition = AloneButtonRestartPosition;
            }
        
            var target = InstantiateGameNode(gameMap.CurrentTargetNode, gameOverScreen);
            _winEffect.Play();

            return target;
        }

        public void StopGameOverController()
        {
            _winEffect.Stop();
        }
    
        private GameNode InstantiateGameNode(GameNode node, Transform gameOverScreen)
        {
            node = Instantiate(node, gameOverScreen);
            var animator = node.GetComponent<Animator>();
            var nodeRectTransform = node.gameObject.GetComponent<RectTransform>();

            animator.enabled = false;
            nodeRectTransform.localScale = ScaleWonNode;
            nodeRectTransform.localPosition = PositionWonNode;
            nodeRectTransform.sizeDelta = RectScaleWonNode;

            node.VibrateNode();

            return node;
        }
    
        private void ReloadButtonPositions(RectTransform reloadButtonPosition)
        {
            _buttonContinue.gameObject.SetActive(true);
            reloadButtonPosition.localPosition = DefaultButtonRestartPosition;
        }
    }
}