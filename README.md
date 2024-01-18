
# Carworld
Deze repository bevat de broncode van het "Carworld" project, een basis CRUD-applicatie ontwikkeld als onderdeel van het tweede semester (2020-2021) richting software engineering van de ICT-studie aan Fontys Hogescholen te Eindhoven.

## Projectbeschrijving
Het idee van Carworld was het creëren van een website met een database van auto's. Gebruikers kunnen hierbij afbeeldingen, prijzen en specificaties van verschillende auto's bekijken, filters toepassen, zoekopdrachten uitvoeren en auto's vergelijken op basis van specificaties. Gebruikers hebben de mogelijkheid om een account aan te maken, waarmee auto's aan favorieten toegevoegd kunnen worden en de gebruiker in staat wordt gesteld nieuwe auto's aan de database toe te voegen.

## Projectstructuur
Het project is geschreven in ASP.NET en is opgedeeld in verschillende subprojecten om een duidelijke overzicht van de verschillende lagen te bieden:

- DAL (Data Access Layer): Verantwoordelijk voor de toegang tot de database.
- Logic Layer: Bevat de logica van de applicatie.
- Contract Layer: Definieert de contracten en interfaces.
- Factory DAL: Implementeert de database toegangsobjecten.
- Unit Test Layer: Bevat unit tests voor de verschillende lagen.
- UI Layer: Verantwoordelijk voor de gebruikersinterface.

## Functionaliteiten
Bij het project zijn verschillende functionele requirements opgesteld. De belangrijkste requirements omvatten onder andere:

- Het bekijken van een overzicht van alle auto's.
- Het sorteren van auto's op basis van specificaties.
- Het zoeken naar auto's op titel.
- Het vergelijken van auto's met een overzicht van specificaties.
- Registratie- en inlogfunctionaliteiten
- Het toevoegen van nieuwe auto's.
- Het favoriet maken van auto's en het bekijken van favorieten.

## Leeruitkomsten
Gedurende het semester zijn de volgende leeruitkomsten aangetoond:

#### 1. Je baseert je keuzes op feedback van stakeholders en onderbouwt ze op een heldere en professionele wijze.
- **Stakeholder:**: Iemand met een bepaalde rol en belang in het project (ongeacht of deze groot of klein is). Je kunt deze stakeholders identificeren en kunt hun belangen achterhalen en prioriteren.
- **Helder en professioneel:** Documentatie is compleet maar compact, niet-triviaal, gecontroleerd op spelfouten en toepasselijk voor de stakeholder waar deze voor bedoeld is.
- **Onderbouwen:** Geef betrouwbare en relevante bronnen voor alle beslissingen. Je beoordeelt bronnen op hun betrouwbaarheid en relevantie voor het project.

#### 2. Je werkt samen en communiceert met anderen op constructieve en professionele manier
- **Professioneel samenwerken**: Je werkt samen aan een gemeenschappelijk doel en neemt initiatieven om het proces te verbeteren.
- **Professioneel communiceren:** Je levert artefacten op aan de stakeholders en hebt zinvolle meetings met het team. Een artefact is een opgeleverd (deel)product dat waarde heeft voor de stakeholder. Voorbeelden zijn: analysedocumenten, ontwerpdocument, code en geïnstalleerde software.
- **Constructief:** Je reflecteert regelmatig op de manier waarop je werkt en hoe je handelen jou, anderen en het projectresultaat beïnvloedt. Hiervoor vraag je regelmatig feedback. Op basis van de informatie die je hieruit verkrijgt, maak je aanpassingen aan je gedrag.

#### 3. Je documenteert gevalideerde gebruikersspecificaties voor applicaties en vertaalt deze in correcte softwareontwerpen.
- **Gevalideerde gebruikersspecificaties:** Gevalideerd: je controleert dat requirements geaccepteerd zijn door de stakeholders en kunt ze zodanig prioriteren dat de eisen die de meeste waarde opleveren voor de stakeholders, de hoogste prioriteit krijgen.
- **Gebruikersspecificaties:** Het verwachte gedrag van het systeem, gespecificeerd in termen van interactie tussen de gebruiker en het systeem. Specificaties worden gevalideerd met behulp van uitvoerbare acceptatietests.
- **Correcte softwareontwerpen:** Je vertaalt specificaties naar relevante diagrammen waarin het technisch ontwerp beschreven wordt en die kunnen worden geïmplementeerd. Diagrammen die relevant kunnen zijn voor het implementeren van het product zijn onder andere: architectuurdiagrammen, domeinmodellen en databaseontwerpen

#### 4. Je bouwt, ontwerpt en levert herhaaldelijk veilige en onderhoudbare applicaties op (waarvan er tenminste één web-gebaseerd is) die verbinding maken met een database en gebruik maken van OO-principes en standaard technieken gebaseerd op gevalideerde gebruikerseisen.
- **Herhaaldelijk:** Je maakt, breidt uit en onderhoud verschillende projecten.
- **Ontwerpen:** Het uitbreiden en onderhouden van projecten begint met herijken van de specificaties en het ontwerp.
- **Opleveren:** Je stelt de software op een dusdanige wijze beschikbaar dat de stakeholders er gebruik van kunnen maken.
- **Veilig:** Een softwaresysteem moet bescherm zijn tegen onbedoelde of onverwachte fouten. Onbedoelde fouten treden op als gebruikers het product gebruiken op een manier die niet was voorzien bij het opstellen van de specificaties. Onverwachte fouten treden op als iets faalt in het systeem, zoals bijvoorbeeld het niet beschikbaar zijn van een verbinding met de database.
- **Onderhoudbaar:** Een ontwerp moet klaar zijn voor toekomstige nieuwe eisen of aanpassingen aan bestaande specificaties
- **OO Principes:** Gebruik gangbare OO-principes om het softwaresysteem te ontwerpen en dit ontwerp te onderbouwen.

#### 5. Je redeneert over computationele uitdagingen en implementeert algoritmisch complexe problemen in software
- **Computationele Uitdagingen:** Je lost veelvoorkomende uitdagingen op, zoals een sorteerprobleem en onderbouwt waarom een bepaalde techniek geschikt is voor specifieke problemen.
- **Algoritmisch complexe problemen:** Je ontwerpt en implementeert algoritmes zodanig dat ze rekening houden met de randvoorwaarden van de stakeholders.

#### 6. Je ontwerpt, bouwt en bevraagt een relationeel databasesysteem en integreert dit met een applicatie.
- **Ontwerpen:** Maak onderscheid tussen database- en softwareontwerpen. Een databaseontwerp bevat meerdere soorten relaties, zoals 1-op-veel en veel-op-veel.
- **Bevragen:** Je voert CRUD-operaties (Create, Read, Update en Delete) uit op data in een relationele database, en houdt rekening met performantie.

#### 7. Je verbetert en toont de kwaliteit van je software continue aan, gebruikmakend van standaard technieken en hulpmiddelen.
- **Continue:** Je werkt op een iteratieve wijze zonder bestaande functionaliteit te verstoren en waarbij veranderingen worden bijgehouden
- **Verbeteren:** Gebruik standaard hulpmiddelen en technieken om de kwaliteit van je code te bewaken en te verbeteren.
- **Aantonen:** De code moet getest worden voor zowel het geplande gebruikt, verwachte en onverwachte foutsituaties. Deze testen moeten meerdere malen kunnen worden uitgevoerd in meerdere fasen van het project. Verwachte fouten kunnen voortkomen uit de specificaties of van externe afhankelijkheden van de software
- **Standaard technieken en hulpmiddelen:** Gebruik bijvoorbeeld een versiebeheersysteem, acceptatietests en unit-tests.

## Opmerkingen
Het gebruik van Entity Framework was niet toegestaan om de data access laag te implementeren. In plaats daarvan zijn eigen SQL-statements geschreven om inzicht te krijgen in het werken met een data access laag op een meer fundamenteel niveau.
