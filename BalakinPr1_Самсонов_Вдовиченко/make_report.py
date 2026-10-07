import os
import docx
from docx import Document
from docx.shared import Pt, Cm, Emu, RGBColor
from docx.enum.text import WD_ALIGN_PARAGRAPH, WD_BREAK
from docx.oxml.ns import qn
from docx.oxml import OxmlElement

TEMPLATE = "/home/cutecruelty/balakintasks/BalakinPr8_Самсонов_Вдовиченко/Отчет_Практика8_Самсонов_Вдовиченко.docx"
OUT = "/tmp/opencode/report/Отчет_Практика1_Самсонов_Вдовиченко.docx"
SHOTS = "/tmp/opencode/shots"
os.makedirs("/tmp/opencode/report", exist_ok=True)

doc = Document(TEMPLATE)

# --- clear body (keep sectPr) ---
body = doc.element.body
for child in list(body):
    if child.tag == qn("w:sectPr"):
        continue
    body.remove(child)


def _set_font(run, size=14, bold=False, italic=False):
    run.font.name = "Times New Roman"
    run.font.size = Pt(size)
    run.bold = bold
    run.italic = italic
    rpr = run._element.get_or_add_rPr()
    rf = rpr.find(qn("w:rFonts"))
    if rf is None:
        rf = OxmlElement("w:rFonts")
        rpr.append(rf)
    for a in ("w:ascii", "w:hAnsi", "w:cs"):
        rf.set(qn(a), "Times New Roman")


def par(text="", size=14, bold=False, align="justify", indent=1.25, line=1.5,
        before=0, after=6, italic=False):
    p = doc.add_paragraph()
    pf = p.paragraph_format
    pf.line_spacing = line
    pf.space_before = Pt(before)
    pf.space_after = Pt(after)
    if align == "justify":
        pf.alignment = WD_ALIGN_PARAGRAPH.JUSTIFY
    elif align == "center":
        pf.alignment = WD_ALIGN_PARAGRAPH.CENTER
    elif align == "right":
        pf.alignment = WD_ALIGN_PARAGRAPH.RIGHT
    if indent:
        pf.first_line_indent = Cm(indent)
    if text:
        r = p.add_run(text)
        _set_font(r, size, bold, italic)
    return p


def page_break():
    p = doc.add_paragraph()
    r = p.add_run()
    r.add_break(WD_BREAK.PAGE)


def caption(text):
    p = doc.add_paragraph()
    p.paragraph_format.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.first_line_indent = Cm(0)
    p.paragraph_format.space_after = Pt(10)
    r = p.add_run(text)
    _set_font(r, 12, False, False)


def figure(path, cap):
    p = doc.add_paragraph()
    p.paragraph_format.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.first_line_indent = Cm(0)
    p.paragraph_format.space_after = Pt(2)
    run = p.add_run()
    run.add_picture(path, width=Cm(15))
    caption(cap)


def _borders(tbl):
    tblPr = tbl._tbl.tblPr
    borders = OxmlElement("w:tblBorders")
    for edge in ("top", "left", "bottom", "right", "insideH", "insideV"):
        el = OxmlElement("w:" + edge)
        el.set(qn("w:val"), "single")
        el.set(qn("w:sz"), "6")
        el.set(qn("w:space"), "0")
        el.set(qn("w:color"), "000000")
        borders.append(el)
    tblPr.append(borders)


def table(headers, rows, cap=None, widths=None):
    if cap:
        caption(cap)
    t = doc.add_table(rows=1, cols=len(headers))
    try:
        t.style = "Table Grid"
    except Exception:
        pass
    _borders(t)
    for i, h in enumerate(headers):
        cell = t.rows[0].cells[i]
        cell.text = ""
        p = cell.paragraphs[0]
        p.paragraph_format.line_spacing = 1.0
        p.paragraph_format.first_line_indent = Cm(0)
        r = p.add_run(str(h))
        _set_font(r, 12, True)
    for row in rows:
        cells = t.add_row().cells
        for i, v in enumerate(row):
            cells[i].text = ""
            p = cells[i].paragraphs[0]
            p.paragraph_format.line_spacing = 1.0
            p.paragraph_format.first_line_indent = Cm(0)
            r = p.add_run(str(v))
            _set_font(r, 12, False)
    if widths:
        for i, w in enumerate(widths):
            for row in t.rows:
                row.cells[i].width = Cm(w)
    par("", after=6)
    return t


# ============================ ТИТУЛЬНЫЙ ЛИСТ ============================
par("МИНИСТЕРСТВО ОБРАЗОВАНИЯ ОРЕНБУРГСКОЙ ОБЛАСТИ", align="center", indent=0, after=0, line=1.0)
par("Государственное автономное профессиональное образовательное учреждение", align="center", indent=0, after=0, line=1.0)
par("«ОРЕНБУРГСКИЙ КОЛЛЕДЖ ЭКОНОМИКИ И ИНФОРМАТИКИ» (ГАПОУ ОКЭИ)", align="center", indent=0, after=0, line=1.0)
for _ in range(8):
    par("", after=0, line=1.0)
par("Практическая работа № 1", align="center", bold=True, indent=0, after=0)
par("«Анализ эффективности сайта и оптимизация загрузки изображений»", align="center", bold=True, indent=0, after=0)
for _ in range(8):
    par("", after=0, line=1.0)
par("Выполнил: Самсонов А. Ю.", align="right", indent=0, after=0)
par("Выполнил: Вдовиченко С. А.", align="right", indent=0, after=0)
par("Группа: 3ВБ1", align="right", indent=0, after=0)
for _ in range(3):
    par("", after=0, line=1.0)
par("2026", align="center", indent=0, after=0)
page_break()

# ============================ МОДУЛЬ 1 ============================
par("Модуль 1. Аудит эффективности сайта covde.oksei.ru средствами Lighthouse",
    bold=True, align="left", indent=0, before=0)
par("Цель работы: освоить инструмент анализа веб-страниц Lighthouse и оценить "
    "эффективность реального сайта, выявить узкие места и сформировать рекомендации.")
par("Объект исследования: официальный сайт системы дистанционного обучения ГАПОУ «ОКЭИ» — "
    "https://covde.oksei.ru/ (система управления обучением Moodle).")
par("Инструмент: Lighthouse — открытый инструмент аудита веб-страниц, который входит в состав "
    "Chrome DevTools и может устанавливаться как отдельный пакет (в работе использована версия "
    "lighthouse, установленная командой npm install -g lighthouse). В качестве альтернативы "
    "использовалась встроенная панель Lighthouse в браузере Chrome. Инструмент оценивает "
    "производительность (Performance), доступность (Accessibility), лучшие практики "
    "(Best Practices) и SEO.")
par("Ход работы:", align="left", indent=0, after=2)
par("1. Установлен инструмент Lighthouse (npm install -g lighthouse).", indent=1.25)
par("2. Выбран легальный сайт — covde.oksei.ru.", indent=1.25)
par("3. Выполнен аудит страницы https://covde.oksei.ru/ в двух режимах: mobile (мобильный) и desktop (настольный).", indent=1.25)
par("4. Зафиксированы оценки по категориям и ключевые метрики Speed Index, FCP, LCP, TBT, CLS, TTI.", indent=1.25)
par("5. Сформирован отчёт Lighthouse (HTML/JSON) и подготовлены скриншоты.", indent=1.25)
par("Внешний вид исследуемой страницы приведён на рисунке 1.", after=2)

figure(os.path.join(SHOTS, "m1_site_home.png"),
       "Рисунок 1 – Главная страница сайта covde.oksei.ru")

par("Отчёт Lighthouse в мобильном режиме включает категории Performance, Accessibility, "
    "Best Practices и SEO; в работе оценка Performance получена отдельным полным запуском "
    "Lighthouse. Общие оценки и метрики приведены на рисунках 2–4 и в таблице 1.", after=2)

figure(os.path.join(SHOTS, "m1_lighthouse_mobile_top.png"),
       "Рисунок 2 – Отчёт Lighthouse для covde.oksei.ru (mobile): общие оценки")
figure(os.path.join(SHOTS, "m1_lighthouse_mobile_metrics.png"),
       "Рисунок 3 – Подробные метрики Lighthouse (mobile)")
figure(os.path.join(SHOTS, "m1_lighthouse_desktop_top.png"),
       "Рисунок 4 – Отчёт Lighthouse для covde.oksei.ru (desktop)")

table(
    ["Показатель", "Mobile", "Desktop"],
    [
        ["Performance (производительность)", "70", "99"],
        ["Accessibility (доступность)", "80", "80"],
        ["Best Practices (лучшие практики)", "100", "100"],
        ["SEO", "83", "83"],
        ["First Contentful Paint (FCP)", "3,3 с", "0,7 с"],
        ["Largest Contentful Paint (LCP)", "5,8 с", "0,9 с"],
        ["Total Blocking Time (TBT)", "130 мс", "0 мс"],
        ["Cumulative Layout Shift (CLS)", "0", "0"],
        ["Speed Index", "3,4 с", "0,7 с"],
        ["Time to Interactive (TTI)", "5,8 с", "1,2 с"],
        ["Общий размер страницы", "679 КиБ", "679 КиБ"],
        ["Время ответа сервера", "140 мс", "140 мс"],
    ],
    cap="Таблица 1 – Результаты аудита Lighthouse для сайта covde.oksei.ru",
    widths=[8.5, 3.2, 3.2],
)

par("Анализ результатов.", bold=True, align="left", indent=0, after=2)
par("В мобильном режиме производительность сайта оценена в 70 баллов — это ниже "
    "рекомендуемого значения 90+. Ключевые проблемы: Largest Contentful Paint равен 5,8 с "
    "(норма — не более 2,5 с) и First Contentful Paint 3,3 с (норма — до 1,8 с). "
    "В настольном режиме сайт показывает 99 баллов и быстрый отклик (LCP 0,9 с), "
    "то есть серверная часть работает хорошо, а замедление проявляется на медленных "
    "мобильных каналах и при ограниченной вычислительной мощности устройства. "
    "Анализ возможностей оптимизации, предложенных Lighthouse, показал наибольший резерв "
    "в неиспользуемом коде: неиспользуемый JavaScript — около 303 КБ (экономия до ~1,8 с), "
    "неиспользуемый CSS — около 109 КБ (до ~0,45 с).")
par("Доступность (80) снижена из-за недостаточного контраста текста, некорректной "
    "структуры ARIA и списков, а также малого размера интерактивных элементов. "
    "SEO (83) снижен из-за отсутствия meta-описания и невалидного файла robots.txt. "
    "Категория Best Practices оценена в 100 баллов.")

par("Рекомендации по результатам модуля 1:", bold=True, align="left", indent=0, after=2)
par("1. Уменьшить объём неиспользуемого JavaScript и CSS (отключить лишние плагины Moodle, "
    "объединить и минифицировать файлы, включать встроенное сжатие gzip/brotli).", indent=1.25)
par("2. Откладывать загрузку некритичных скриптов (defer/async) и подключать только нужный код.", indent=1.25)
par("3. Применить отложенную загрузку изображений и современные форматы (loading=lazy, WebP) — "
    "это подробно исследовано в модуле 2.", indent=1.25)
par("4. Добавить meta-описание страницы и исправить robots.txt для улучшения SEO.", indent=1.25)
par("5. Повысить контраст текста, увеличить области нажатия и исправить ARIA-разметку и "
    "структуру списков для роста доступности.", indent=1.25)
par("6. Настроить кэширование статических ресурсов и использовать CDN.", indent=1.25)

page_break()

# ============================ МОДУЛЬ 2 ============================
par("Модуль 2. Влияние атрибута loading=\u201clazy\u201d и формата WebP на скорость "
    "загрузки изображений", bold=True, align="left", indent=0, before=0)
par("Цель работы: измерить влияние отложенной загрузки изображений (атрибут loading=\"lazy\") "
    "и современного формата WebP на скорость и метрики загрузки страницы с большим количеством "
    "«тяжёлых» изображений.")
par("Тестовый стенд: HTML-страница, содержащая 6 изображений разрешением 3600×2700 пикселей. "
    "Исходные изображения сохранены в формате JPEG с массой около 5,2 МБ каждое (суммарно "
    "около 31,4 МБ), что удовлетворяет требованию задания «не менее 5 МБ на изображение». "
    "Те же изображения преобразованы в формат WebP. Для точности все ресурсы отдавались "
    "локальным веб-сервером с запретом кэширования. Замеры выполнялись в браузере Chrome "
    "(DevTools, вкладки Performance и Network) при эмуляции сети Slow 4G и размере окна 900×600.")
par("Размеры изображений приведены в таблице 2.", after=2)

table(
    ["Изображение", "JPEG, МБ", "WebP, МБ"],
    [
        ["img1", "5,27", "0,16"],
        ["img2", "5,24", "0,15"],
        ["img3", "5,26", "0,15"],
        ["img4", "5,20", "0,15"],
        ["img5", "5,22", "0,15"],
        ["img6", "5,23", "0,15"],
        ["Итого", "31,4", "0,9"],
    ],
    cap="Таблица 2 – Размеры изображений тестового стенда",
    widths=[6.0, 4.4, 4.4],
)

par("Ход работы. Было проведено четыре эксперимента с одинаковым набором изображений:", after=2)
par("1. JPEG без атрибута loading (изображения загружаются сразу).", indent=1.25)
par("2. JPEG с атрибутом loading=\"lazy\" (изображения ниже первого экрана загружаются отложенно).", indent=1.25)
par("3. WebP без атрибута loading.", indent=1.25)
par("4. WebP с атрибутом loading=\"lazy\".", indent=1.25)
par("Результаты фиксировались по списку сетевых запросов и метрикам страницы. "
    "Порядок действий по заданию также включал: удаление модификатора loading, "
    "просмотр метрик, возврат модификатора, повторный просмотр, преобразование изображений "
    "в WebP и сравнение всех вариантов. Скриншоты замеров приведены на рисунках 5–8, "
    "сводные результаты — в таблице 3.", after=2)

figure(os.path.join(SHOTS, "m2_jpeg_nolazy.png"),
       "Рисунок 5 – JPEG без loading=lazy (все 6 изображений загружаются сразу)")
figure(os.path.join(SHOTS, "m2_jpeg_lazy.png"),
       "Рисунок 6 – JPEG с loading=lazy (часть изображений отложена)")
figure(os.path.join(SHOTS, "m2_webp_nolazy.png"),
       "Рисунок 7 – WebP без loading=lazy")
figure(os.path.join(SHOTS, "m2_webp_lazy.png"),
       "Рисунок 8 – WebP с loading=lazy")

table(
    ["Вариант", "Запрошено изображений", "Передано данных", "Комментарий"],
    [
        ["JPEG без lazy", "6 из 6", "≈31,4 МБ", "все изображения грузятся при открытии"],
        ["JPEG с lazy", "3 из 6", "≈15,7 МБ", "нижние изображения отложены до прокрутки"],
        ["WebP без lazy", "6 из 6", "≈0,9 МБ", "полная загрузка страницы"],
        ["WebP с lazy", "0–3 из 6", "≈0,9 МБ", "подгрузка по мере появления на экране"],
    ],
    cap="Таблица 3 – Результаты замеров загрузки изображений (Slow 4G, окно 900×600)",
    widths=[3.6, 3.6, 3.2, 5.0],
)

par("Анализ результатов.", bold=True, align="left", indent=0, after=2)
par("Без атрибута loading=\"lazy\" браузер при открытии страницы запрашивает все 6 изображений "
    "сразу — передаётся около 31,4 МБ в формате JPEG. С атрибутом loading=\"lazy\" браузер "
    "откладывает загрузку изображений, находящихся ниже первого экрана: в момент первичной "
    "загрузки запрошены только 3 изображения из 6 (около 15,7 МБ), остальные подгружаются "
    "при прокрутке страницы. Это сокращает объём первичной загрузки примерно вдвое.")
par("Преобразование в формат WebP дало значительно больший эффект: суммарный объём "
    "изображений уменьшился с 31,4 МБ до 0,9 МБ, то есть примерно в 35 раз при визуально "
    "сопоставимом качестве. Именно формат изображений является главным фактором, "
    "влияющим на Largest Contentful Paint: чем меньше вес изображения, тем быстрее "
    "оно отображается. Комбинация WebP + loading=\"lazy\" является оптимальной: "
    "наименьший объём данных и отложенная загрузка невидимых изображений.")

par("Вывод по модулю 2.", bold=True, align="left", indent=0, after=2)
par("Атрибут loading=\"lazy\" уменьшает объём первоначально загружаемых данных за счёт "
    "отложенной загрузки изображений вне первого экрана. Формат WebP радикально "
    "уменьшает вес изображений (в данном эксперименте — примерно в 35 раз). "
    "Для быстрых страниц с изображениями следует использовать оба приёма одновременно, "
    "а также задавать размеры изображений, чтобы избежать сдвигов макета (CLS).")

page_break()
par("Общий вывод", bold=True, align="left", indent=0, before=0)
par("В ходе практической работы освоен инструмент анализа веб-страниц Lighthouse и "
    "выполнен аудит реального сайта covde.oksei.ru. Установлено, что на настольных "
    "компьютерах сайт работает эффективно (Performance 99), однако на мобильных "
    "устройствах производительность снижается до 70 баллов из-за большого объёма "
    "неиспользуемого кода и медленной отрисовки. Сформированы рекомендации по "
    "оптимизации: сокращение неиспользуемого JS/CSS, добавление meta-описания, "
    "исправление robots.txt, повышение доступности и применение отложенной загрузки.")
par("В рамках модуля 2 на тестовом стенде из 6 «тяжёлых» изображений экспериментально "
    "подтверждено, что атрибут loading=\"lazy\" и формат WebP существенно ускоряют "
    "загрузку: lazy сокращает объём первичной загрузки примерно вдвое, а WebP уменьшает "
    "вес изображений примерно в 35 раз. Наилучший результат даёт совместное применение "
    "обоих приёмов. Цель работы достигнута.")

doc.save(OUT)
print("saved", OUT, os.path.getsize(OUT), "bytes")
