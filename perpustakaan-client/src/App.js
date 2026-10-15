import { useState, useEffect } from 'react';
import axios from 'axios';

const API_BASE = 'http://localhost:5280/api';

function App() {
  const [activeTab, setActiveTab] = useState('buku');

  // State Jenis Buku
  const [jenisBukuList, setJenisBukuList] = useState([]);
  const [inputJenis, setInputJenis] = useState('');
  const [editJenisId, setEditJenisId] = useState(null);

  // State Buku
  // const [bukuList, setBukuList] = useState([]);
  // const [search, setSearch] = useState('');
  // const [formBuku, setFormBuku] = useState({
  //   judul: '',
  //   penulis: '',
  //   jenisBukuId: '',
  //   tanggalRilis: '',
  //   jumlahHalaman: ''
  // });
  // const [editBukuId, setEditBukuId] = useState(null);

  // // State Histori
  // const [selectedBukuHistory, setSelectedBukuHistory] = useState(null);
  // const [historyList, setHistoryList] = useState([]);

  useEffect(() => {
    fetchJenisBuku();
    // fetchBuku();
  }, []);

  // --- CRUD Master Jenis Buku ---
  const fetchJenisBuku = async () => {
    const res = await axios.get(`${API_BASE}/JenisBuku`);
    setJenisBukuList(res.data);
  };

  const handleSaveJenis = async (e) => {
    e.preventDefault();
    if (editJenisId) {
      await axios.put(`${API_BASE}/JenisBuku/${editJenisId}`, { jenisBuku: inputJenis });
    } else {
      await axios.post(`${API_BASE}/JenisBuku`, { jenisBuku: inputJenis });
    }
    setInputJenis('');
    setEditJenisId(null);
    fetchJenisBuku();
  };

  const handleDeleteJenis = async (id) => {
    if (window.confirm('Hapus jenis buku ini?')) {
      await axios.delete(`${API_BASE}/JenisBuku/${id}`);
      fetchJenisBuku();
    }
  };

  return (
    <div style={{ padding: '24px', fontFamily: 'Arial, sans-serif' }}>
      <h2>Aplikasi Manajemen Perpustakaan</h2>
        <div style={{ marginBottom: '16px' }}>
        <button onClick={() => setActiveTab('buku')} style={{ fontWeight: activeTab === 'buku' ? 'bold' : 'normal', marginRight: '8px' }}>Data Buku</button>
        <button onClick={() => setActiveTab('jenis')} style={{ fontWeight: activeTab === 'jenis' ? 'bold' : 'normal' }}>Master Jenis Buku</button>
      </div>

      {/* --- TAB MASTER JENIS BUKU --- */}
      {activeTab === 'jenis' && (
        <div>
          <h3>Master Data Jenis Buku (Soal 1)</h3>
          <form onSubmit={handleSaveJenis} style={{ marginBottom: '16px' }}>
            <input
              type="text"
              placeholder="Jenis Buku (e.g. Fiksi, Novel)"
              value={inputJenis}
              onChange={(e) => setInputJenis(e.target.value)}
              required
              style={{ marginRight: '8px', padding: '6px' }}
            />
            <button type="submit">{editJenisId ? 'Update' : 'Simpan'}</button>
            {editJenisId && (
              <button type="button" onClick={() => { setEditJenisId(null); setInputJenis(''); }} style={{ marginLeft: '4px' }}>Batal</button>
            )}
          </form>

          <table border="1" cellPadding="8" style={{ borderCollapse: 'collapse', width: '50%' }}>
            <thead>
              <tr style={{ background: '#f2f2f2' }}>
                <th>ID</th>
                <th>Jenis Buku</th>
                <th>Aksi</th>
              </tr>
            </thead>
            <tbody>
              {jenisBukuList.map((item) => (
                <tr key={item.id}>
                  <td>{item.id}</td>
                  <td>{item.jenisBuku}</td>
                  <td>
                    <button onClick={() => { setEditJenisId(item.id); setInputJenis(item.jenisBuku); }}>Edit</button>
                    <button onClick={() => handleDeleteJenis(item.id)} style={{ marginLeft: '4px' }}>Hapus</button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}

      {activeTab === 'buku' && (
        <div>Buku</div>
      )}
    </div>
  );
}

export default App;
