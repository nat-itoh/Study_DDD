using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BmiApp.Composition
{
    public class TransitionOverlay : MonoBehaviour
    {
		[SerializeField] float _fadeDuration = 0.5f;
		[SerializeField] Ease _fadeEase = Ease.OutCubic;

		[SerializeField]
		CanvasGroup m_CanvasGroup;

		public UniTask StartTransition(CancellationToken cancellationToken = default) {
			return m_CanvasGroup.DOFade(1f, _fadeDuration)
				.SetEase(_fadeEase)
				.ToUniTask(cancellationToken: cancellationToken);
		}

		public UniTask EndTransition(CancellationToken cancellationToken = default) {
			return m_CanvasGroup.DOFade(0f, _fadeDuration)
				.SetEase(_fadeEase)
				.ToUniTask(cancellationToken: cancellationToken);
		}
	}
}
