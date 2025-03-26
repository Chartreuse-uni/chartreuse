$(document).ready(function () {
  const toggle = $('#metricsToggle');

  const subGrids = {
    sol: ['#sol-energy', '#sol-finance'],
    kiran: ['#kiran-energy', '#kiran-finance'],
    jint: ['#jint-energy', '#jint-finance'],
    rasyid: ['#rasyid-energy', '#rasyid-finance'],
  };

  function switchMode(mode) {
    const isEnergy = mode === 'energy';

    // Switch main views
    Object.values(subGrids).forEach(([energySelector, financeSelector]) => {
      $(energySelector).toggle(isEnergy);
      $(financeSelector).toggle(!isEnergy);
    });

    // Switch metric values inside boxes
    if (isEnergy) {
      $('.energy-value, .energy-title').show();
      $('.finance-value, .finance-title').hide();
    } else {
      $('.energy-value, .energy-title').hide();
      $('.finance-value, .finance-title').show();
    }
  
    localStorage.setItem('metricsMode', mode);
  }

  // On initial load
  const saved = localStorage.getItem('metricsMode') || 'energy';
  toggle.prop('checked', saved === 'financial');
  switchMode(saved);

  // On toggle change
  toggle.on('change', function () {
    const mode = $(this).is(':checked') ? 'financial' : 'energy';
    switchMode(mode);
  });
});
