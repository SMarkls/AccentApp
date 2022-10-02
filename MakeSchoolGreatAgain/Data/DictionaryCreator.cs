﻿using System;
using System.IO;

namespace AccentApp.Data
{
    /// <summary>
    /// Class creates file with words
    /// </summary>
    class DictionaryCreator
    {
        private string words = @"аэропОрты
    бАнты
    бОроду
    бухгАлтеров
    вероисповЕдание
    граждАнство
    дефИс
    дешевИзна
    диспансЕр
    договорЁнность
    докумЕнт
    досУг
    еретИк
    жалюзИ
    знАчимость
    Иксы
    каталОг
    квартАл
    киломЕтр
    кОнусы
    корЫсть
    крАны
    кремЕнь
    кремнЯ
    лЕкторы
    лЕкторов
    лыжнЯ
    мЕстностей
    намЕрение
    нарОст
    нЕдруг
    недУг
    некролОг
    каталОг
    нЕнависть
    нОвости
    новостЕй
    нОготь
    Отрочество
    партЕр
    портфЕль
    пОручни
    придАное
    призЫв
    свЁкла
    сирОты
    срЕдства
    созЫв
    стАтуя
    столЯр
    тамОжня
    тОрты
    тОртов
    цемЕнт
    цЕнтнер
    цепОчка
    шАрфы
    шофЁр
    экспЕрт
    намЕрение
    нарОст
    нЕдруг
    недУг
    некролОг
    каталОг
    нЕнависть
    нОвости
    новостЕй
    нОготь
    нОгтя
    Отрочество
    партЕр
    портфЕль
    пОручни
    придАное
    призЫв
    свЁкла
    сирОты
    срЕдства
    созЫв
    стАтуя
    столЯр
    тамОжня
    тОрты
    тОртов
    цемЕнт
    цЕнтнер
    цепОчка
    шАрфы
    шофЁр
    экспЕрт
    бралА
    бралАсь
    взялА
    взялАсь
    влилАсь
    ворвалАсь
    воспринялА
    воссоздалА
    вручИт
    гналА
    гналАсь
    добралА
    добралАсь
    дождалАсь
    дозвонИтся
    дозвонЯтся
    дозИровать
    ждалА
    жилОсь
    закУпорить
    зАнял
    занялА
    зАняло
    зАняли
    заперлА
    заперлАсь
    звалА
    звонИть
    звонИшь
    звонИт
    звонИм
    исчЕрпать
    клАла
    клЕить
    крАлась
    лгалА
    лилА
    лилАсь
    навралА
    наделИт
    надорвалАсь
    назвалАсь
    накренИтся
    налилА
    нарвалА
    насорИт
    нАчал
    началА
    нАчали
    обзвонИт
    облегчИт
    облилАсь
    обнялАсь
    обогналА
    ободралА
    ободрИть
    ободрИшься
    обострИть
    оптОвый
    одолжИт
    озлОбить
    оклЕить
    окружИт
    опломбировАть
    опОшлить
    освЕдомишься
    отбылА
    отдалА
    откУпорил
    отозвалА
    отозвалАсь
    перезвонИт
    перелилА
    плодоносИть
    повторИт
    позвалА
    позвонИшь
    позвонИт
    полилА
    положИл
    понялА
    послАла
    прИбыл
    прибылА
    прИбыло
    прИнял
    прИняли
    принялА
    принУдить
    рвалА
    сверлИшь
    сверлИт
    слИвовый
    снялА
    создалА
    сорвалА
    сорИт
    убралА
    убыстрИть
    углубИть
    укрепИт
    чЕрпать
    щемИт
    защемИт
    щЁлкать
    балОванный
    включЁн
    довезЁнный
    доЯр
    зАгнутый
    зАнятый
    занятА
    зАпертый
    запертА
    заселЁнный
    заселенА
    избалОванный
    балОванный
    кормЯщий
    кровоточАщий
    молЯщий
    мозаИчный
    нажИвший
    нАжитый
    нажитА
    налИвший
    налитА
    нанЯвшийся
    начАвший
    нАчатый
    начатА
    низведЁнный
    низведЁн
    включЁнный
    ободрЁн
    ободренА
    обострЁнный
    определЁнный
    определЁн
    отключЁнный
    повторЁнный
    поделЁнный
    понЯвший
    прИнятый
    приручЁнный
    прожИвший
    прожОрлива
    снЯтый
    снятА
    сОгнутый
    балУясь
    закУпорив
    начАв
    начАвшись
    отдАв
    поднЯв
    понЯв
    прибЫв
    создАв
    вОвремя
    дОверху
    донЕльзя
    дОнизу
    дОсуха
    завИдно
    зАгодя
    зАсветло
    зАтемно
    красИвее
    прил.и
    надОлго
    ненадОлго
    мусоропровОд
    газопровОд
    нефтепровОд
    водопровОд
    диалОг
    монолОг";
        public DictionaryCreator()
        {
            using (var stream = File.CreateText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Dictionary.txt")))
            {
                stream.Write(words);
            }
        }
    }
}