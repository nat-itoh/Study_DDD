using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using Project.Application.Memos.UseCase;
using Project.Domain.Memos.Repository;
using Project.Infrastructure.SQLiteNet.Memos;

public class MemoUITest : MonoBehaviour {
    [Header("Create Memo")]
    public InputField TitleInput;
    public InputField ContentInput;
    public Button CreateButton;

    [Header("Memo List")]
    public Transform MemoListContent;
    public Text MemoTemplate;
    public Button RefreshButton;

    [Header("Edit Memo")]
    public InputField EditTitleInput;
    public InputField EditContentInput;
    public Button UpdateButton;
    public Button DeleteButton;

    private IMemoRepository _repository;
    private MemoUseCase _useCase;
    private Guid? _selectedMemoId;

    private async void Start() {
        // 初期化
        _repository = new SQLiteMemoRepository();
        _useCase = new MemoUseCase(_repository);

        // イベントの設定
        CreateButton.onClick.AddListener(OnCreateButtonClicked);
        RefreshButton.onClick.AddListener(OnRefreshButtonClicked);
        UpdateButton.onClick.AddListener(OnUpdateButtonClicked);
        DeleteButton.onClick.AddListener(OnDeleteButtonClicked);

        // メモ一覧を初期表示
        await RefreshMemoList();
    }

    private async void OnCreateButtonClicked() {
        string title = TitleInput.text;
        string content = ContentInput.text;

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content)) {
            Debug.LogWarning("Title or Content is empty!");
            return;
        }

        await _useCase.CreateMemoAsync(title, content);
        TitleInput.text = string.Empty;
        ContentInput.text = string.Empty;

        await RefreshMemoList();
    }

    private async void OnRefreshButtonClicked() {
        await RefreshMemoList();
    }

    private async void OnUpdateButtonClicked() {
        if (!_selectedMemoId.HasValue) {
            Debug.LogWarning("No memo selected for update.");
            return;
        }

        string newTitle = EditTitleInput.text;
        string newContent = EditContentInput.text;

        await _useCase.UpdateMemoAsync(_selectedMemoId.Value, newTitle, newContent);
        await RefreshMemoList();
    }

    private async void OnDeleteButtonClicked() {
        if (!_selectedMemoId.HasValue) {
            Debug.LogWarning("No memo selected for deletion.");
            return;
        }

        await _useCase.DeleteMemoAsync(_selectedMemoId.Value);
        _selectedMemoId = null;

        EditTitleInput.text = string.Empty;
        EditContentInput.text = string.Empty;

        await RefreshMemoList();
    }

    private async UniTask RefreshMemoList() {
        // メモ一覧をクリア
        foreach (Transform child in MemoListContent) {
            Destroy(child.gameObject);
        }

        // メモ一覧を取得して表示
        var memos = await _useCase.GetAllMemosAsync();
        foreach (var memo in memos) {
            var memoText = Instantiate(MemoTemplate, MemoListContent);
            memoText.text = $"{memo.Title}: {memo.Content}";
            memoText.gameObject.SetActive(true);

            // メモがクリックされたときの処理
            var id = memo.Id;
            memoText.GetComponent<Button>().onClick.AddListener(() => {
                _selectedMemoId = id;
                EditTitleInput.text = memo.Title;
                EditContentInput.text = memo.Content.ToString();
            });
        }
    }

    private void OnDestroy() {
        _repository?.Dispose();
    }
}
