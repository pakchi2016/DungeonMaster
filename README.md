# 基本設計書: 堕落と循環のゲームシステム (Corruption & Cycle System)

## 1. 概要 (Overview)
本システムは、以下の3つの循環エンジンによって構成される。
1.  **生存機関 (Survival)**: ダンジョン攻略とリソース管理。
2.  **快楽機関 (Eros)**: 戦闘中の性的ステータスと強制覚醒。
3.  **経済機関 (Economy)**: 敗北によるバッドスキル獲得と、娼館での価値転換。

---

## 2. 生存機関と快楽機関 (Survival & Eros Engine)
HPをメンタルに変換して稼働し続ける「生気変換」と「強制覚醒」のロジック。

```mermaid
graph TD;
    %% パラメータ定義
    HP[HP: 生命力]
    Mental[Mental: 意識/気力]
    EP[EP: 快感値]
    Lust[Lust: 欲求不満/発情]

    %% 処理フロー
    Damage(敵の攻撃/責め) -->|減少| HP
    Damage -->|増加| EP
    
    EP -->|最大値到達| Orgasm(絶頂判定)
    
    Orgasm -->|Yes: 強烈な消費| Mental
    Orgasm -->|Yes: 解消| Lust
    
    Mental -->|0になる| Faint(失神/無力化)
    
    %% 特殊ギミック: 生気変換
    EnemySkill{敵スキル: 生気変換}
    Faint --> EnemySkill
    EnemySkill -->|HPを吸収して変換| HP
    HP -.->|強制回復| Mental
    EnemySkill -->|強制復帰| Faint
```

### 主要パラメータ (Parameters)

| 変数名 | 型 | 説明・役割 |
| :--- | :--- | :--- |
| **`HP`** | `int` | 生命力。0で敗北。「生気変換」のリソース源となる。 |
| **`Mental`** | `int` | 気力。0で行動不能。絶頂するたびに減少する。 |
| **`EP`** (Excite Point) | `float` | 快感蓄積値。`Sensitivity` × `Stimulation` で増加。 |
| **`Orgasm_Count`** | `int` | 絶頂回数。回数が多いほどMentalダメージ倍率が上昇。 |
| **`Awakening_State`** | `bool` | 「強制覚醒」フラグ。ONの間はHPが継続減少し、Mentalが底上げされる。 |

---

## 3. 快楽制御機関 (Control & Denial Engine)
「寸止め中毒」や「機械管理」による、快楽の蓄積と管理ロジック。

```mermaid
graph TD;
    %% 入力
    ExtStim[外部刺激: 機械/ケーブル] -->|加算| EP

    %% 寸止めロジック
    LimitCheck{寸止め制御}
    EP --> LimitCheck
    
    LimitCheck --> |閾値（99%）到達: 遮断| Denial(寸止め発生)
    LimitCheck --> |許可| Orgasm(絶頂)

    %% プールの蓄積
    Denial -->|行き場のない快感を貯蓄| Frustration_Pool[欲求不満プール]
    
    %% フィードバック
    Frustration_Pool -->|徐々に変換| Lust[Lust: 基本発情度]
    Lust -->|ベース感度を底上げ| Sensitivity[感度倍率]
    
    Sensitivity -->|次回のEP増加量をブースト| ExtStim
```

### 主要パラメータ (Parameters)

| 変数名 | 型 | 説明・役割 |
| :--- | :--- | :--- |
| **`Frustration_Pool`** | `float` | 寸止めされた快感の蓄積プール。時間経過でLustやStressに変換。 |
| **`Lust`** (Libido) | `int` | 基礎発情度。高いとEPの自然減少が停止し、常に興奮状態になる。 |
| **`Min_EP_Floor`** | `float` | EPの下限値。ケーブル/ローター接続時はこれ以下に下がらない。 |
| **`Denial_Level`** | `int` | 寸止め強度。高いほどFrustrationの蓄積効率が上がる。 |

---

## 4. 経済機関とバッドスキル (Economy & Bad Skills Engine)
ダンジョンでの「傷（Bad Skill）」が、娼館での「商品価値（Value）」に反転するロジック。

```mermaid
graph TD;
    %% ダンジョンでの結果
    Defeat(敗北/強制送還) -->|要因判定| BadSkill_Get(バッドスキル獲得)
    
    %% バッドスキルの二面性
    BadSkill_Get -->|デバフ: 被ダメ増など| Dungeon_Stat[ダンジョン性能]
    BadSkill_Get -->|バフ: 商品価値UP| Brothel_Value[娼館: 基礎単価]
    
    %% 娼館での行動
    Work_Menu{労働メニュー}
    
    Work_Menu -->|個室: 密室管理| Earn_Money[報酬獲得]
    Work_Menu -->|ロビー: 磔見せしめ| Customer_Up[集客率UP]
    
    %% リスクとコスト
    Earn_Money -->|蓄積| Stress[ストレス/SAN値低下]
    Customer_Up -->|激減| SAN[SAN値: 理性]
    
    %% 循環
    BadSkill_Level{スキル深度}
    Work_Menu -.->|経験値| BadSkill_Level
    BadSkill_Level -->|さらに悪化/強化| BadSkill_Get
```

### 主要パラメータ (Parameters)

| 変数名 | 型 | 説明・役割 |
| :--- | :--- | :--- |
| **`BadSkill_List`** | `List<Skill>` | 所持スキルリスト。各スキルが`Price_Multiplier`（価格倍率）を持つ。 |
| **`Market_Value`** | `int` | 1時間あたりの基本価格。BadSkillの質と量で決定。 |
| **`Customer_Rate`** | `float` | 集客率。「磔イベント」などで一時的にブーストされる。 |
| **`SAN`** (Sanity) | `int` | 理性値。0になると廃人化、または完全自動行動モードへ移行。 |
| **`Debt`** | `int` | 借金総額。返済できない場合、ペナルティイベントが発生。 |

---

## 5. インベントリ・状態管理 (Inventory & State)

| カテゴリ | パラメータ名 | 型 | 説明 |
| :--- | :--- | :--- | :--- |
| **身体スロット** | **`Womb_Content`** | `Class` | 子宮内状態。`{Type: "Egg", Timer: 100}`。敏捷性低下などのデバフ付与。 |
| **装備状態** | **`Costume_ID`** | `Enum` | 現在の衣装。`Armor`（防御）、`OL_Suit`（精神ダメ増/羞恥）など。 |
| **接続状態** | **`Connected_Device`** | `Enum` | `None`, `Cable`, `Pillory`(磔)。行動制約とEP下限値を決定。 |

## 6. クラス設計のヒント (Architecture Hints)

* **`VitalityManager`**: HP, Mental, 生気変換の計算を担当。
* **`SensationManager`**: EP, 絶頂, 寸止め, Lustの計算を担当。毎フレーム `Frustration` を更新。
* **`CorruptionManager`**: バッドスキル, 娼館の価格, SAN値の計算
