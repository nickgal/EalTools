using System;
using System.Collections.Generic;

using EalTools.Eal;
using EalTools.Riff;

namespace EalTools
{
    public class EalData : RiffData
    {
        public string ExecuteProgram { get; private set; }
        public string ExecuteParameters { get; private set; }
        public EaxGlobalDiffractionModel? GlobalDiffractionModel { get; set; }
        public EaxListenerAttributes? ListenerAttributes { get; set; }
        public EaxListenerProperties? DefaultEnvironment { get; set; }
        public EaxMaterialAttributes? DefaultObstacle { get; set; }
        public EaxSourceAttributes? DefaultSource { get; set; }
        public List<EnvironmentProperties> EnvironmentModels { get; set; } = new List<EnvironmentProperties>();
        public List<GeometryProperties> GeometrySets { get; set; } = new List<GeometryProperties>();
        public List<MaterialProperties> ObstacleModels { get; set; } = new List<MaterialProperties>();
        public List<SourceProperties> SourceModels { get; set; } = new List<SourceProperties>();

        public EalData(RiffChunk riffChunk) : base(riffChunk)
        {
            SetExec();
            SetGlobalDiffractionModel();
            SetListenerAttributes();
            SetDefaultEnvironment();
            SetDefaultObstacle();
            SetDefaultSource();
            SetEnvironmentModels();
            SetGeometrySets();
            SetObstacleModels();
            SetSourceModels();
        }

        private void SetExec()
        {
            ExecuteProgram = _riffChunk.FindSubChunk<ExepChunk>()?.Executable ?? string.Empty;
            ExecuteParameters = _riffChunk.FindSubChunk<CmdsChunk>()?.Commands ?? string.Empty;
        }

        private void SetGlobalDiffractionModel()
        {
            GlobalDiffractionModel = _riffChunk.FindSubChunk<GdfmChunk>()?.DiffractionModel;
        }

        private void SetListenerAttributes()
        {
            ListenerAttributes = _riffChunk.FindSubChunk<LisaChunk>()?.ListenerAttributes;
        }

        private void SetDefaultEnvironment()
        {
            DefaultEnvironment = _riffChunk.FindSubChunk<DenvChunk>()?.ListenerProperties;
        }

        private void SetDefaultObstacle()
        {
            DefaultObstacle = _riffChunk.FindSubChunk<DmatChunk>()?.MaterialAttributes;
        }

        private void SetDefaultSource()
        {
            DefaultSource = _riffChunk.FindSubChunk<DsrcChunk>()?.SourceAttributes;
        }

        private void SetEnvironmentModels()
        {
            if (!_riffChunk.TryFindListOfForm(FourCC.Envp, out var listChunk)) return;

            if (!listChunk.TryFindSubChunk<NumChunk>(out var numChunk)) return;
            if (!listChunk.TryFindSubChunk<NamsChunk>(out var namsChunk)) return;
            if (!listChunk.TryFindSubChunk<LispChunk>(out var lispChunk)) return;

            for (int i = 0; i < numChunk.Number; i++)
            {
                EnvironmentModels.Add(new EnvironmentProperties()
                {
                    Name = namsChunk.Names[i],
                    ListenerProperties = lispChunk.ListenerProperties[i],
                });
            }
        }

        private void SetGeometrySets()
        {
            if (!_riffChunk.TryFindListOfForm(FourCC.Gemp, out var listChunk)) return;

            if (!listChunk.TryFindSubChunk<NumChunk>(out var numChunk)) return;
            if (!listChunk.TryFindSubChunk<NamsChunk>(out var namsChunk)) return;
            if (!listChunk.TryFindSubChunk<FilsChunk>(out var filsChunk)) return;
            if (!listChunk.TryFindSubChunk<GemaChunk>(out var gemaChunk)) return;

            for (int i = 0; i < numChunk.Number; i++)
            {
                GeometrySets.Add(new GeometryProperties()
                {
                    Name = namsChunk.Names[i],
                    Filepath = filsChunk.Filepaths[i],
                    GeometryAttributes = new EalGeometryAttributes() // gemaChunk.GeometryAttributes[i], // FIXME:
                });
            }
        }

        private void SetObstacleModels()
        {
            if (!_riffChunk.TryFindListOfForm(FourCC.Matp, out var listChunk)) return;

            if (!listChunk.TryFindSubChunk<NumChunk>(out var numChunk)) return;
            if (!listChunk.TryFindSubChunk<NamsChunk>(out var namsChunk)) return;
            if (!listChunk.TryFindSubChunk<MataChunk>(out var mataChunk)) return;

            for (int i = 0; i < numChunk.Number; i++)
            {
                ObstacleModels.Add(new MaterialProperties()
                {
                    Name = namsChunk.Names[i],
                    MaterialAttributes = mataChunk.MaterialAttributes[i],
                });
            }
        }

        private void SetSourceModels()
        {
            if (!_riffChunk.TryFindListOfForm(FourCC.Srcp, out var listChunk)) return;

            if (!listChunk.TryFindSubChunk<NumChunk>(out var numChunk)) return;
            if (!listChunk.TryFindSubChunk<NamsChunk>(out var namsChunk)) return;
            if (!listChunk.TryFindSubChunk<FilsChunk>(out var filsChunk)) return;
            if (!listChunk.TryFindSubChunk<SrcaChunk>(out var srcaChunk)) return;

            for (int i = 0; i < numChunk.Number; i++)
            {
                SourceModels.Add(new SourceProperties()
                {
                    Name = namsChunk.Names[i],
                    Filepath = filsChunk.Filepaths[i],
                    SourceAttributes = srcaChunk.SourceAttributes[i],
                });
            }
        }
    }
}
